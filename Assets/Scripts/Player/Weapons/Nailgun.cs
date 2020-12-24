using System;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class Nailgun : MonoBehaviour, IWeapon
    {
        
        [SerializeField] [Range(1, 10)] private int damage = 4;
        [SerializeField] [Range(1, 50)] private int startingAmmo = 20;
        [SerializeField] [Range(0.01f, 1f)] private float reloadTime = 0.25f;
        private int _ammo;
        private WeaponMode _mode = WeaponMode.Hold;
        private float _currentReloadTime;
        public WeaponMode GetMode() => _mode;

        private void Start()
        {
            _ammo = startingAmmo;
        }

        private void Update()
        {
            if (HasReloaded()) return;
            _currentReloadTime += Time.deltaTime;
        }

        public void TryAttack(IDamageable target)
        {
            if (!HasReloaded() || _ammo <= 0) return;
            target.GetHurt(damage);
            _ammo--;
            _currentReloadTime -= reloadTime;
        }

        public IDamageable CheckForTarget(Vector3 from, Vector3 to)
        {
            Physics.Raycast(from, to, out RaycastHit hit, 1000f);
            if (hit.collider != null && hit.collider.TryGetComponent(out IDamageable validTarget))
                return validTarget;
            else
                return null;
        }

        public bool HasReloaded()
        {
            return _currentReloadTime > reloadTime;
        }
    }
}