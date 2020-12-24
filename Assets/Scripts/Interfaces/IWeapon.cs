using SantasHelper.Player.Weapons;
using UnityEngine;

namespace SantasHelper.Interfaces
{
    public enum WeaponMode
    {
        Hold,
        Release,
        Press
    }
    
    public interface IWeapon
    {
        void TryAttack(IDamageable target);
        IDamageable CheckForTarget(Vector3 from, Vector3 to);
        WeaponMode GetMode();
        float GetReloadTime();

    }
}