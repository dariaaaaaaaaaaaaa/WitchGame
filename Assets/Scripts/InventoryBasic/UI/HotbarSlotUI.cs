using UnityEngine;
using UnityEngine.UI;

namespace InventoryBasic.UI
{
    public class HotbarSlotUI : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private Image iconImage;

        public int Id => id;

        public void SetActive(bool isActive)
        {
            iconImage.gameObject.SetActive(isActive);
        }
    }
}