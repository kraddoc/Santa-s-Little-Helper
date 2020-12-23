using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public enum FireMode
    {
        Hold,
        Release,
        Press
    }

    public class WeaponUser
    {
        private IWeapon _currentWeapon;


        public WeaponUser(IWeapon currentWeapon)
        {
            _currentWeapon = currentWeapon;
        }

        public void ChangeWeapon(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }

        public void TryAttack(Vector3 castOrigin, Vector3 direction)
        {
            Physics.SphereCast(castOrigin, _currentWeapon.GetHitRadius(), direction, out var hitInfo,
                _currentWeapon.GetHitRange());
            if (hitInfo.collider == null)
                return;

            if (hitInfo.collider.TryGetComponent(out IDamageable target)) _currentWeapon.Attack(target);
            else return;
        }

        public FireMode GetFireMode() => _currentWeapon.GetFireMode();
    }
}