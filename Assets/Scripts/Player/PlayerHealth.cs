using System;
using UnityEngine;

namespace SantasHelper.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void Damage()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
                print("ouch im ded");
        }
    }
}