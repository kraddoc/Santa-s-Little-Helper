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
        [SerializeField] [Range(0.1f, 1f)] private float reloadTime = 0.3f;
        [SerializeField] private WeaponMode mode = WeaponMode.Release;
        private float _holdTime;
        private bool IsHolding => Input.GetButton("Fire1");
        public WeaponMode GetMode() => mode;
        public float GetReloadTime() => reloadTime;
        
        private void Update()
        {
            if (IsHolding)
                _holdTime += Time.deltaTime;
            else
                _holdTime = 0;
        }
        
        public void Attack(IDamageable target)
        { 
            target.Damage(GetDamage(_holdTime));
        }

        public IDamageable CheckForTarget(Vector3 from, Vector3 to)
        {
            Physics.SphereCast(from, hitRadius, to, out var hit, hitRange);
            return hit.collider != null && hit.collider.TryGetComponent(out IDamageable validTarget)
                ? validTarget
                : null;
        }
        

        private int GetDamage(float holdTime)
        {
            var currentDamage = (int) Mathf.Lerp(minDamage, maxDamage, holdTime / interpolationTime);
            return currentDamage;
        }
    }
}