using System;
using SantasHelper.Player;
using SantasHelper.Tags;
using UnityEngine;

namespace SantasHelper.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 3f)] private float attackTime = 1f;
        [SerializeField] [Range(0.1f, 1f)] private float attackDistance = 0.5f;
        private float _currentAttackTime;
        public bool IsAttacking { get; private set; }
        private Transform _player;
        private PlayerHealth _playerHealth;

        private void Update()
        {
            if (!IsAttacking)
                return;
            
            _currentAttackTime += Time.deltaTime;
            
            if (_currentAttackTime >= attackTime)
                EndAttack();
        }

        public void PassPlayerReference(PlayerObject player)
        {
            _player = player.transform;
            _player.TryGetComponent(out _playerHealth);
        }

        public bool CloseEnough()
        {
            return Vector3.Distance(_player.position, transform.position) <= attackDistance;
        }
            
        public void StartAttack()
        {
            if (IsAttacking || _player == null)
                return;
            IsAttacking = true;
            _currentAttackTime = 0f;
        }

        private void EndAttack()
        {
            IsAttacking = false;
            _currentAttackTime = 0f;
            if (CloseEnough())
            {
                _playerHealth.Damage();
            }

        }
        
        
        
        
    }
}