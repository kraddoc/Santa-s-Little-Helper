using System;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Interactables
{
    public class GiftBox : MonoBehaviour, IInteractable
    {
        [SerializeField] private Material opaque;
        private Renderer _renderer;

        private void Awake()
        {
            TryGetComponent(out _renderer);
        }


        public void Interact()
        {
            _renderer.material = opaque;
        }
    }
}