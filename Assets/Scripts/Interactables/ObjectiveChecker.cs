using SantasHelper.UI;
using UnityEngine;
using UnityEngine.UI;

namespace SantasHelper.Interactables
{
    public class ObjectiveChecker : MonoBehaviour
    {
        [SerializeField] private Image has;
        [SerializeField] private Image total;
        [SerializeField] private GameObject winScreen;
        
        private int _boxesToWin;
        private int _currently;

        private SpriteHolder sprites;
        
        
        private void Start()
        {
            _boxesToWin = FindObjectsOfType<GiftBox>().Length;
            _currently = 0;

            sprites = SpriteHolder.instance;

            has.sprite = sprites.Numbers[_currently];
            print(_boxesToWin);
            total.sprite = sprites.Numbers[_boxesToWin];
        }

        public void AddBox()
        {
            _currently++;
            has.sprite = sprites.Numbers[_currently];
            if (_currently >= _boxesToWin)
            {
                Win();
            }
        }

        private void Win()
        {
            winScreen.SetActive(true);
        }    
    }
}