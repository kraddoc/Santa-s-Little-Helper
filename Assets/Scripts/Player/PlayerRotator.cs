using UnityEngine;

namespace SantasHelper.Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private Transform rotator;
        private Transform _transform;

        private void Awake()
        {
            if (rotator == null)
                enabled = false;

            TryGetComponent(out _transform);
        }

        private void Update()
        {
            _transform.eulerAngles = Vector3.up * rotator.eulerAngles.y;
        }
    }
}