using System;
using UnityEngine;

namespace SantasHelper.UI
{
    public class SpriteHolder : MonoBehaviour
    {
        [SerializeField] public Sprite[] Numbers = new Sprite[10];
        public static SpriteHolder instance;

        private void Awake()
        {
            instance = this;
        }
        
        
    }
}
