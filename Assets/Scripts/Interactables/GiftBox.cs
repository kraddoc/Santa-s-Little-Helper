using System;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Interactables
{
    public class GiftBox : MonoBehaviour, IInteractable
    {
        [SerializeField] private Material opaque;
        [SerializeField] private ObjectiveChecker collector;
        [SerializeField] private Renderer renderer;
        private bool _hasInteracted = false;


        public void Interact()
        {
            if (_hasInteracted)
                return;
            renderer.material = opaque;
            collector.AddBox();
            _hasInteracted = true;
            enabled = false;
        }
    }
}