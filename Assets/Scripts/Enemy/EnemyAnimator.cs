using UnityEngine;

namespace SantasHelper.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Sprite deathSprite;
        [SerializeField] [Range(0.1f, 2f)]private float flipInterval = 0.7f;
        private SpriteRenderer _sprite;
        private float _flipTimer;

        private void Start()
        {
            TryGetComponent(out _sprite);
        }

        private void Update()
        {
            if (_flipTimer < flipInterval)
            {
                _flipTimer += Time.deltaTime;
                return;
            }
            _flipTimer -= flipInterval;
            _sprite.flipX = !_sprite.flipX;
        }

        public void Die()
        {
            _sprite.sprite = deathSprite;
            enabled = false;
        }
    }
}
