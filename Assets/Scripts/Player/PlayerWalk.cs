using UnityEngine;

namespace SantasHelper.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerWalk : MonoBehaviour
    {
        [SerializeField] [Range(1f, 10f)] private float speed = 6f;
        [SerializeField] [Range(0f, 20f)] private float gravity = 13f;
        [SerializeField] [Range(0f, 0.5f)] private float inertia = 0.3f;
        private CharacterController _controller;

        private Vector3 _currentDirection = Vector3.zero;
        private Vector3 _smoothVelocity = Vector3.zero;
        private Transform _transform;

        private float _verticalVelocity;

        private void Awake()
        {
            TryGetComponent(out _transform);
            TryGetComponent(out _controller);
        }

        private void Update()
        {
            _controller.Move(GetSmoothedDirection() * (speed * Time.deltaTime) +
                             Vector3.down * CalculateVerticalVelocity());
        }

        private Vector3 GetSmoothedDirection()
        {
            var inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            var localized = _transform.TransformDirection(inputDir).normalized;

            _currentDirection = Vector3.SmoothDamp(_currentDirection, localized, ref _smoothVelocity, inertia);

            return _currentDirection;
        }

        private float CalculateVerticalVelocity()
        {
            if (_controller.isGrounded)
                _verticalVelocity = 0f;

            _verticalVelocity += gravity * Time.deltaTime;
            return _verticalVelocity;
        }
    }
}