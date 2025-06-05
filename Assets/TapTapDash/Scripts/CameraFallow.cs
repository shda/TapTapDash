using UnityEngine;

namespace TapTapDash.Scripts
{
    public class CameraFallow : MonoBehaviour
    {
        [SerializeField] private Transform cameraTarget;
        [SerializeField] private Transform cameraFallow;
        [SerializeField] private Transform target;
        [SerializeField] private float offset = 0.1f;

        private Vector3 _lastPosition;

        private void Awake()
        {
            _lastPosition = transform.position;
        }

        private void Update()
        {
            var offsetTarget = target.position - _lastPosition;
            _lastPosition = target.position;
            
            cameraFallow.position +=  offsetTarget * offset;
            cameraFallow.transform.rotation = cameraTarget.transform.rotation;
        }
    }
}