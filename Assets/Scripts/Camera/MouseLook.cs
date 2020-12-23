using UnityEngine;

namespace SantasHelper.Camera
{
    public class MouseLook : MonoBehaviour
    {
        [Header("Smoothness")] 
        [SerializeField] [Range(0f, 500f)]
        private float sensitivity = 50f;

        [SerializeField] [Range(0f, 0.1f)] 
        private float smoothTime = 0.025f;

        [Header("Vertical look restrictions")] 
        [SerializeField] [Range(-90f, -60f)]
        private float yMinRotation = -80f;

        [SerializeField] [Range(60f, 90f)] 
        private float yMaxRotation = 90f;

        [Header("Hide cursor.")] [SerializeField]
        private bool lockAndHideCursor = true;

        private Vector3 _currentRotation = Vector3.zero;
        private Vector3 _currentRotationVelocity = Vector3.zero;
        private float _mouseX;
        private float _mouseY;
        private Transform _transform;

        private void Awake()
        {
            TryGetComponent(out _transform);
            if (lockAndHideCursor) //TODO probably move to another script??
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void Update()
        {
            Rotate(GetMouseRotation());
        }

        private Vector3 GetMouseRotation()
        {
            _mouseY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            _mouseX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            _mouseX = Mathf.Clamp(_mouseX, -yMaxRotation, -yMinRotation);

            _currentRotation = Vector3.SmoothDamp(_currentRotation, new Vector3(_mouseX, _mouseY, 0),
                ref _currentRotationVelocity, smoothTime);

            return _currentRotation;
        }

        private void Rotate(Vector3 eulerAngles)
        {
            //TODO is directly setting rotation the best option? Gotta look into it.
            _transform.localRotation = Quaternion.Euler(eulerAngles);
        }
    }
}