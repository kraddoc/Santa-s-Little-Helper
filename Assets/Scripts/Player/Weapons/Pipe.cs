using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class Pipe : MonoBehaviour, IWeapon
    {
        [SerializeField] [Range(1, 10)] private int minDamage = 1;
        [SerializeField] [Range(2, 10)] private int maxDamage = 5;
        [SerializeField] [Range(0.01f, 1f)] private float interpolationTime = 0.5f;
        [SerializeField] [Range(0.1f, 3f)] private float hitRange = 1f;
        [SerializeField] [Range(0.1f, 3f)] private float hitRadius = 1f;
        [SerializeField] private FireMode fireMode = FireMode.Release;
        private float _holdTime;
        private bool IsHolding => Input.GetButton("Fire1");

        private void Update()
        {
            if (IsHolding)
                _holdTime += Time.deltaTime;
            else
                _holdTime = 0;
        }

        public float GetHitRange() => hitRange;
        public float GetHitRadius() => hitRadius;
        public FireMode GetFireMode() => fireMode;

        public void Attack(IDamageable target) => target.Damage(GetDamage(_holdTime));

        
        private int GetDamage(float holdTime)
        {
            var currentDamage = (int) Mathf.Lerp(minDamage, maxDamage, holdTime / interpolationTime);
            return currentDamage;
        }
    }
}