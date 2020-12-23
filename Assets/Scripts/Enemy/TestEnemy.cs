using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Enemy
{
    public class TestEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] [Range(1, 10)] private int maxHealth = 10;
        private int _health;
        private bool IsAlive => _health > 0;

        private void Awake()
        {
            _health = maxHealth;
        }

        public void Damage(int damage)
        {
            print($"Got {damage.ToString()} damage ");
            _health -= damage;
            if (!IsAlive)
                Die();
        }

        private void Die()
        {
            print("I died");
        }
    }
}