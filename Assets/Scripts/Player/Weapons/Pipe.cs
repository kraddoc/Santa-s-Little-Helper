using System;
using System.Threading;
using SantasHelper.Interfaces;
using UnityEngine;

namespace SantasHelper.Player.Weapons
{
    [RequireComponent(typeof(Animator))]
    public class Pipe : MonoBehaviour, IWeapon
    {
        [SerializeField] [Range(1, 10)] private int minDamage = 1;
        [SerializeField] [Range(2, 10)] private int maxDamage = 5;
        [SerializeField] [Range(0.01f, 1f)] private float interpolationTime = 0.5f;
        [SerializeField] [Range(0.1f, 3f)] private float hitRange = 1f;
        [SerializeField] [Range(0.1f, 1f)] private float reloadTime = 0.3f;
        [SerializeField] private WeaponMode mode = WeaponMode.Release;
        public WeaponMode GetMode() => mode;
        private float _holdTime;
        private float _currentReloadTime;
        private bool IsHolding => Input.GetButton("Fire1");
        private Animator _animator;

        private void Awake()
        {
            TryGetComponent(out _animator);
        }

        private void Update()
        {
            if (!HasReloaded())
                _currentReloadTime += Time.deltaTime;
         
            _animator.SetBool("IsCharging", IsHolding);
            
            if (IsHolding)
                _holdTime += Time.deltaTime;
            else
                _holdTime = 0;
        }
        
        public void TryAttack(IDamageable target)
        {
            if (!HasReloaded()) return;
            _currentReloadTime -= reloadTime;
            if (target != null)
                target.GetHurt(GetDamage(_holdTime));

        }
        
        public bool HasReloaded()
        {
            return _currentReloadTime > reloadTime;
        }

        public IDamageable CheckForTarget(Vector3 from, Vector3 to)
        {
            Physics.Raycast(from, to, out var hit, hitRange);
            return hit.collider != null && hit.collider.TryGetComponent(out IDamageable validTarget)
                ? validTarget
                : null;
        }
        

        private int GetDamage(float holdTime)
        {
            var currentDamage = (int) Mathf.Lerp(minDamage, maxDamage, holdTime / interpolationTime);
            return currentDamage;
        }
    }
}