using System;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        public Action OnDeath;
        
        [SerializeField] [Range(1, 25)] private int maxHealth = 10;
        private int _healthCurrent;
        
        private void OnEnable()
        {
            _healthCurrent = maxHealth;
        }

        public void GetHurt(int damage)
        {
            _healthCurrent -= damage;
            print($"Got hit for {damage.ToString()} damage");
            if (_healthCurrent <= 0)
                Die();
        }

        private void Die()
        {
            print("I died");
            OnDeath?.Invoke();
        }
    }
}