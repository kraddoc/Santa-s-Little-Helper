using UnityEngine;

namespace SantasHelper.Enemy
{
    public class SimpleAnimate : MonoBehaviour
    {
        private SpriteRenderer _sprite;

        private void Start()
        {
            TryGetComponent(out _sprite);
        }
    }
}
