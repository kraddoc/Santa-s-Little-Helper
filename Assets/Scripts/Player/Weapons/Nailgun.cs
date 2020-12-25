using System;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    [RequireComponent(typeof(Animator))]
    public class Nailgun : MonoBehaviour, IWeapon
    {
        
        [SerializeField] [Range(1, 10)] private int damage = 4;
        [SerializeField] [Range(1, 50)] private int startingAmmo = 20;
        [SerializeField] [Range(0.01f, 1f)] private float reloadTime = 0.25f;
        [SerializeField] private WeaponMode mode = WeaponMode.Hold;
        private int _ammo;
        private float _currentReloadTime;
        private Animator _animator;
        private bool IsShooting => Input.GetButton("Fire1") && _ammo > 0;
        public WeaponMode GetMode() => mode;

        private void Start()
        {
            _ammo = startingAmmo;
            TryGetComponent(out _animator);
        }

        private void Update()
        {

            _animator.SetBool("IsShooting", IsShooting);

            if (HasReloaded()) return;
            _currentReloadTime += Time.deltaTime;
        }

        public void TryAttack(IDamageable target)
        {
            if (!HasReloaded() || _ammo <= 0) return;
            _ammo--;
            _currentReloadTime -= reloadTime;
            if (target != null)
                target.GetHurt(damage);
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

        public void GiveAmmo(int amount)
        {
            _ammo += amount;
        }
    }
}