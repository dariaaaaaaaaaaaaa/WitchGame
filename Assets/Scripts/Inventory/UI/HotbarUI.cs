using System.Collections.Generic;
using Core.ManagersSystem;
using Inventory.Logic;
using UnityEngine;

namespace Inventory.UI
{
    public class HotbarUI : MonoBehaviour
    {
        [SerializeField] private List<HotbarSlotUI> slots;
        
        private readonly ManagerReference<InventoryManager> _inventoryManager = new ManagerReference<InventoryManager>();

        private void Start()
        {
            _inventoryManager.Value.OnCurrentSlotChanged += RenderSlots;
            RenderSlots();
        }

        private void RenderSlots()
        {
            var currentSlot = _inventoryManager.Value.CurrentSlot;
            foreach (var slot in slots)
            {
                slot.SetActive(slot.Id == currentSlot);
            }
        }
    }
}