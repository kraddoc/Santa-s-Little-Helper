using System;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    [RequireComponent(typeof(WeaponHandler))]
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private Pipe pipe;
        [SerializeField] private Nailgun nailgun;
        private WeaponHandler _weaponHandler;

        private void Awake()
        {
            TryGetComponent(out _weaponHandler);
            pipe.gameObject.SetActive(false);
            nailgun.gameObject.SetActive(true);
            _weaponHandler.ChangeWeapon(nailgun);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) //this gonna scale really well
            {
                nailgun.gameObject.SetActive(false);
                pipe.gameObject.SetActive(true);
                _weaponHandler.ChangeWeapon(pipe);
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                pipe.gameObject.SetActive(false);
                nailgun.gameObject.SetActive(true);
                _weaponHandler.ChangeWeapon(nailgun);
            }
        }
    }
}