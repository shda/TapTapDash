using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform sprite;
        [SerializeField] private float radiusCheckFail = 1.0f;
        [SerializeField] private float speedMoving = 1.0f;
        [SerializeField] private float jumpTime = 0.3f;
        public Direction Direction { get; set; }
        
        private Vector2 _direction;
        public bool IsMoving { get; set; } = true;
        public bool IsInJump { get; set; } = false;

        private void Awake()
        {
            SetDirection(Direction.Up);
        }

        private void Update()
        {
           // ChackFail();
            MovingForward();
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;

            _direction = direction.ToVector2();
            var angle = direction.ToAngle();

            sprite.transform.rotation = Quaternion.Euler(0,0,angle);
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
            IsInJump = true;
            await transform.DOScale(new Vector3(1.3f, 1.3f, 11.3f), 0.1f);
            await UniTask.Delay(TimeSpan.FromSeconds(jumpTime));
            IsInJump = false;
            
            await transform.DOScale(Vector3.one, 0.1f);
        }
    }
}