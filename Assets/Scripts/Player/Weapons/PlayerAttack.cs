using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        [SerializeField] private Pipe weapon;//TODO move to another script
        private WeaponUser useWeapon;

        private void Start()
        {
            useWeapon = new WeaponUser(weapon);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (useWeapon.GetFireMode() == FireMode.Hold || useWeapon.GetFireMode() == FireMode.Press)
                {
                    useWeapon.TryAttack(camera.position-camera.forward, camera.forward);
                }
            }
            else if (Input.GetButton("Fire1"))
            {
                if (useWeapon.GetFireMode() == FireMode.Hold)
                {
                    useWeapon.TryAttack(camera.position-camera.forward, camera.forward);
                }
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                if (useWeapon.GetFireMode() == FireMode.Release)
                {
                    useWeapon.TryAttack(camera.position-camera.forward, camera.forward);
                }
            }
        }
    }
}