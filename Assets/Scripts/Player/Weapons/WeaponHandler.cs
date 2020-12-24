using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Pipe pipe;
        private IWeapon _weapon; //should only be changed with ChangeWeapon()
        private Transform _camera; //used to provide hit check direction

        private float _reloadTime;
        private float _currentReloadTime = 0f;
        private bool IsReloading => _currentReloadTime <= _reloadTime;
        private WeaponMode _mode;

        private void Start()
        {
            ChangeWeapon(pipe);
            _camera = UnityEngine.Camera.main?.transform;
        }

        private void Update()
        {
            //now what I think about checking for this is probably weapons responsibility, not the handlers
            //TODO move to weapon class later
            if (IsReloading) //it's not reload as in "changing magazines", more like necessary time between shots/hits
            {
                _currentReloadTime += Time.deltaTime;
                return;
            }
            
            if (Input.GetButtonDown("Fire1") && _mode == WeaponMode.Press)
            {
                TryAttack();
            } 
            else if (Input.GetButtonUp("Fire1") && _mode == WeaponMode.Release)
            {
                TryAttack();
            }
            else if (Input.GetButton("Fire1") && _mode == WeaponMode.Hold)
            {
                TryAttack();
            }
        }

        public void ChangeWeapon(IWeapon weapon)
        {
            _weapon = weapon;
            _reloadTime = _weapon.GetReloadTime();
            _mode = _weapon.GetMode();
        }

        private void TryAttack()
        {
            _currentReloadTime -= _reloadTime; //reset reload

            var forward = _camera.forward; //if using just _camera.position sometimes doesn't detect hits close up,
                                                  //reducing it by _camera.forward seems to help
            IDamageable target = _weapon.CheckForTarget(_camera.position - forward, forward);
            if (target != null)
            {
                _weapon.Attack(target);
            }
                
        }
        
    }
}