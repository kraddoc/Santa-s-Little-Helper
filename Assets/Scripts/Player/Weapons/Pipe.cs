using System;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class Pipe : MonoBehaviour, IWeapon
    {
        [SerializeField] [Range(1, 10)] private int minDamage = 1;
        [SerializeField] [Range(2, 10)] private int maxDamage = 5;
        [SerializeField] [Range(0.01f, 1f)] private float interpolationTime = 0.5f;
        private int _currentDamage;
        private float _holdTime;
        private bool _isHolding;
        
        
        
        
        public void Attack(IDamageable target)
        {
            target.Damage(5);
        }

        private void Hold(float holdTime)
        {
            _currentDamage = (int) Mathf.Lerp(minDamage, maxDamage, holdTime / interpolationTime);
        }
    }
}