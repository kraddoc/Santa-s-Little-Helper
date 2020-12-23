using SantasHelper.Player.Weapons;

namespace SantasHelper.Interfaces
{
    
    
    public interface IWeapon
    {
        void Attack(IDamageable target);

        float GetHitRange();

        float GetHitRadius();

        FireMode GetFireMode();
    }
}