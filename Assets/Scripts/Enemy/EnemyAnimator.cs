using System;
using UnityEngine;

namespace SantasHelper.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Sprite deathSprite;
        [SerializeField] private Sprite attackSprite;
        [SerializeField] private Sprite walkSprite;
        [SerializeField] [Range(0.1f, 2f)]private float flipInterval = 0.7f;
        private SpriteRenderer _sprite;
        private float _flipTimer;
        private bool _isWalking;

        private void Start()
        {
            TryGetComponent(out _sprite);
        }

        private void OnEnable()
        {
            TryGetComponent(out _sprite);
            Walk();
        }

        private void Update()
        {
            if (!_isWalking)
                return;
            
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
            _isWalking = false;
        }

        public void Attack()
        {
            _sprite.sprite = attackSprite;
            _isWalking = false;
        }

        public void Walk()
        {
            _sprite.sprite = walkSprite;
            _isWalking = true;
        }
    }
}
