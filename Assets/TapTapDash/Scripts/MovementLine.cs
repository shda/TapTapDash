using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace TapTapDash.Scripts
{
    [ExecuteInEditMode]
    public class MovementLine : MonoBehaviour
    {
        [SerializeField] private Direction directionAfterTab;
        [SerializeField] private ArrowChangeDirection arrowChangeDirection;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public SpriteRenderer Sprite => spriteRenderer;
        public ArrowChangeDirection ArrowChangeDirection => arrowChangeDirection;

        public Direction DirectionAfterTab => directionAfterTab;

        private void Update()
        {
#if UNITY_EDITOR
            UpdateArrowRotation();
#endif
        }

        private void UpdateArrowRotation()
        {
            arrowChangeDirection.transform.rotation = directionAfterTab switch
            {
                Direction.Left => Quaternion.LookRotation(Vector3.forward, Vector3.left),
                Direction.Right => Quaternion.LookRotation(Vector3.forward, Vector3.right),
                Direction.Up => Quaternion.LookRotation(Vector3.forward, Vector3.up),
                Direction.Down => Quaternion.LookRotation(Vector3.forward, Vector3.down),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}