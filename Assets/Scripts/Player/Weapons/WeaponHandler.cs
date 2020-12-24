using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        private IWeapon _weapon;
        private Transform _camera;

        private float _reloadTime;
        private WeaponMode _mode;

        public void ChangeWeapon(IWeapon weapon)
        {
            _weapon = weapon;
            _reloadTime = _weapon.GetReloadTime();
            _mode = _weapon.GetMode();
        }

    }
}