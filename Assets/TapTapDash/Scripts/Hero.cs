using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform sprite;
        [SerializeField] private Transform shadow;
        [SerializeField] private float radiusCheckFail = 1.0f;
        [SerializeField] private float speedMoving = 1.0f;
        [SerializeField] private float rotateSpeed = 1.0f;
        [SerializeField] private float jumpDistance = 1.0f;
        public Direction Direction { get; set; }

        private Vector2 _direction;
        public bool IsMoving { get; set; } = true;
        public bool IsInJump { get; set; } = false;

        private Quaternion _rotation = Quaternion.identity;

        private void Awake()
        {
            SetDirection(Direction.Up, true);
        }

        private void Update()
        {
            MovingForward();

            var q = Quaternion.Lerp(sprite.transform.rotation, _rotation, Time.deltaTime * rotateSpeed);
            sprite.transform.rotation = q;
            shadow.transform.rotation = q;
        }

        public void SetDirection(Direction direction, bool isForce = false)
        {
            Direction = direction;

            _direction = direction.ToVector2();
            var angle = direction.ToAngle();
            _rotation = Quaternion.Euler(0, 0, angle);

            if (isForce)
            {
                sprite.transform.rotation = _rotation;
                shadow.transform.rotation = _rotation;
            }
        }


        public Collider2D GetCollider()
        {
            return Physics2D.OverlapCircle(transform.position, radiusCheckFail);
        }

        private void MovingForward()
        {
            if (IsMoving)
            {
                transform.position += (Vector3)_direction * (speedMoving * Time.deltaTime);
            }
        }

        public async void StartJumpAsync()
        {
            //0.54 time to jumo
            IsInJump = true;

            var startPosition = transform.position;
            transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f);

            var shadowSize = 0.8f;
            shadow.DOScale(new Vector3(shadowSize, shadowSize, shadowSize), 0.1f);

            var startTime = Time.realtimeSinceStartup;
            var maxTimeJimp = 3.0f;
            while (Vector3.Distance(startPosition, transform.position) < jumpDistance && maxTimeJimp > 0)
            {
                maxTimeJimp -= Time.deltaTime;
                await UniTask.Yield();
            }
            
            Debug.Log(Time.realtimeSinceStartup - startTime);

            // await UniTask.Delay(TimeSpan.FromSeconds(jumpTime));
            IsInJump = false;

            transform.DOScale(Vector3.one, 0.1f);
            shadow.DOScale(new Vector3(1, 1, 1), 0.1f);
        }

        public void SetSpeed(float speed)
        {
            speedMoving = speed;
        }

        public void AddSpeed(float addSpeed)
        {
            speedMoving += addSpeed;
        }
    }
}