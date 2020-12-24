using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        private IWeapon _weapon; //should only be changed with ChangeWeapon()
        private Transform _camera; //used to provide hit check direction
        
        private float _currentReloadTime;
        private WeaponMode _mode;

        private void Start()
        {
            _camera = UnityEngine.Camera.main?.transform;
        }

        private void Update()
        {
            if (CanTryAttack())
            {
                TryAttack();
            }
        }

        public void ChangeWeapon(IWeapon weapon)
        {
            _weapon = weapon;
            _mode = _weapon.GetMode();
        }

        private void TryAttack()
        {

            var forward = _camera.forward; //if using just _camera.position sometimes doesn't detect hits close up,
                                                  //reducing it by _camera.forward seems to help
            IDamageable target = _weapon.CheckForTarget(_camera.position - forward, forward);
            if (target != null)
            {
                _weapon.TryAttack(target);
            }
                
        }

        private bool CanTryAttack()
        {
            return (Input.GetButtonDown("Fire1") && _mode == WeaponMode.Press) ||
                   (Input.GetButtonUp("Fire1") && _mode == WeaponMode.Release) ||
                   (Input.GetButton("Fire1") && _mode == WeaponMode.Hold);
        }
        
    }
}