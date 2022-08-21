using GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class HotbarSlotUI : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private Image iconImage;
        [SerializeField] private GameObject selectedView;

        public int Id => id;

        public void SetSelected(bool isActive)
        {
            selectedView.SetActive(isActive);
        }

        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }
        
        public void SetHasIcon(bool hasIcon)
        {
            iconImage.gameObject.SetActive(hasIcon);
        }
    }
}