using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] private float detectRange = 1f;
        [SerializeField] private GameObject promt;
        private Transform _camera;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main.transform;
        }

        private void Update()
        {
            Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, detectRange);
            if (hit.collider == null) return;
            if (!hit.collider.TryGetComponent(out IInteractable interactable))
            {
                promt.SetActive(false);
                return;
            }
            promt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("interacted");
                interactable.Interact();
                promt.SetActive(false);
            }
        }
    }
}
