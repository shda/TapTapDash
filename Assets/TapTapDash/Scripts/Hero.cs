using System;
using UnityEngine;

namespace TapTapDash.Scripts
{
   // [ExecuteInEditMode]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform sprite;
        [SerializeField] private float radiusCheckFail = 1.0f;
        [SerializeField] private float speedMoving = 1.0f;

        private Vector2 _direction;
        public bool IsMoving { get; set; } = true;

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
            _direction = direction switch
            {
                Direction.Left => Vector2.left,
                Direction.Right => Vector2.right,
                Direction.Up => Vector2.up,
                Direction.Down => Vector2.down,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
            
            float angle = direction switch
            {
                Direction.Left => 90,
                Direction.Right => -90 ,
                Direction.Up => 0,
                Direction.Down => 180,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

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
                transform.position += (Vector3)_direction * speedMoving * Time.deltaTime;
            }
        }
    }
}