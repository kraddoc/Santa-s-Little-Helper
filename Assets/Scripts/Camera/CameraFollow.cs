using UnityEngine;

namespace SantasHelper.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] [Range(0f, 5f)] private float smoothFactor = 0.1f;
        private Vector3 _offset = Vector3.zero;
        private Transform _transform;
        private Vector3 _velocity = Vector3.zero;

        private void Awake()
        {
            if (target == null)
                enabled = false;

            TryGetComponent(out _transform);
            _offset = _transform.position - target.position;
        }

        private void LateUpdate()
        {
            Follow(target);
        }

        private void Follow(Transform currentTarget)
        {
            _transform.position = Vector3.SmoothDamp(_transform.position, currentTarget.position + _offset,
                ref _velocity, smoothFactor);
        }
    }
}