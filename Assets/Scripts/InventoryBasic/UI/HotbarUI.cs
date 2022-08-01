using System.Collections.Generic;
using InventoryBasic.Logic;
using UnityEngine;

namespace InventoryBasic.UI
{
    public class HotbarUI : MonoBehaviour
    {
        [SerializeField] private List<HotbarSlotUI> slots;

        private void Start()
        {
            InventoryManager.Instance.OnCurrentSlotChanged += RenderSlots;
            RenderSlots();
        }

        private void RenderSlots()
        {
            var currentSlot = InventoryManager.Instance.CurrentSlot;
            foreach (var slot in slots)
            {
                slot.SetActive(slot.Id == currentSlot);
            }
        }
    }
}