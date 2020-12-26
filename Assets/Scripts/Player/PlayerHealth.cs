using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SantasHelper.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private int maxHealth = 3;
        [SerializeField] private GameObject[] hearts;
        [SerializeField] private GameObject deathScreen;
        private int _currentHealth;
        private float _regenTime = 10f;
        private float _currentRegen = 0f;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        private void Update()
        {
            if (_currentHealth == maxHealth)
                return;

            _currentRegen += Time.deltaTime;
            
            if (_currentRegen >= _regenTime)
            {
                _currentRegen -= _regenTime;
                AddHeart();
                _currentHealth++;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }

        public void Damage()
        {
            _currentHealth--;
            RemoveHeart();
            if (_currentHealth <= 0)
                deathScreen.SetActive(true);
        }

        private void RemoveHeart()
        {
            if (_currentHealth < 0)
                return;
            hearts[_currentHealth].gameObject.SetActive(false);
        }

        private void AddHeart()
        {
            hearts[_currentHealth].gameObject.SetActive(true);
        }
    }
}