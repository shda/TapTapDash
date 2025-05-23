using System;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class RotateCameraByHeroDirection : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        private float _angle;
        public void SetDirection(Direction direction)
        {
            _angle = direction switch
            {
                Direction.Left => 40,
                Direction.Right => -40 ,
                Direction.Up => 0,
                Direction.Down => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            }; 
        }

        private void Update()
        {
            cameraTransform.transform.rotation = Quaternion.Lerp(
                cameraTransform.transform.rotation ,  Quaternion.Euler(0,0,_angle) , Time.deltaTime * 3.0f);
        }
    }
}