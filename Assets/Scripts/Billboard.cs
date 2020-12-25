using System;
using UnityEngine;

namespace SantasHelper
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        private Transform _transform;

        private void Start()
        {
            TryGetComponent(out _transform);
        }

        private void LateUpdate()
        {
            _transform.forward = -camera.forward;
            _transform.localEulerAngles = new Vector3(0, _transform.localEulerAngles.y, 0);
        }
    }
}