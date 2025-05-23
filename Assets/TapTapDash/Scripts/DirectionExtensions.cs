using System;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public static class DirectionExtensions
    {
        public static Vector2 ToVector2(this Direction direction)
        {
            return direction switch
            {
                Direction.Left => Vector2.left,
                Direction.Right => Vector2.right,
                Direction.Up => Vector2.up,
                Direction.Down => Vector2.down,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
        
        public static float ToAngle(this Direction direction)
        {
            return  direction switch
            {
                Direction.Left => 90,
                Direction.Right => -90 ,
                Direction.Up => 0,
                Direction.Down => 180,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}