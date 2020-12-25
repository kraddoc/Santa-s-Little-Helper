using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private float detectRange = 1f;
        private Transform _camera;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main.transform;
        }

        private void Update()
        {
            Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, detectRange, 2);
            if (hit.collider == null) return;
            if (!hit.collider.TryGetComponent(out IInteractable interactable)) return;
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
    }
}
