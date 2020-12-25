using System;
using SantasHelper.Interfaces;
using SantasHelper.Player.Weapons;
using UnityEngine;

namespace SantasHelper.Interactables
{
    //don't have time to implement it correctly this should do for now
    //TODO maybe fix this after jam??
    public class NailBox : MonoBehaviour, IInteractable
    {
        [SerializeField] private int ammo = 20;
        [SerializeField] private Nailgun gun;
        
        public void Interact()
        {
            if (gun == null)
                throw new Exception("nail box didnt had gun doofus");
            
            gun.GiveAmmo(ammo);
        }
    }
}