using System.Collections.Generic;
using Core.ManagersSystem;
using Inventory.Configs;
using Inventory.Logic;
using UnityEngine;

namespace Inventory.UI
{
    public class HotbarUI : MonoBehaviour
    {
        [SerializeField] private List<HotbarSlotUI> slots;
        [SerializeField] private ItemsConfig itemsConfig;

        private readonly ManagerReference<InventoryManager>
            _inventoryManager = new ManagerReference<InventoryManager>();

        private void Start()
        {
            _inventoryManager.Value.OnCurrentSlotChanged += RenderSlots;
            _inventoryManager.Value.OnUpdated += RenderSlots;
            RenderSlots();
        }

        private void RenderSlots()
        {
            var currentSlot = _inventoryManager.Value.CurrentSlot;
            var slotsInfo = _inventoryManager.Value.GetSlotsInfo();
            for (var i = 0; i < slotsInfo.Count && i < slots.Count; i++)
            {
                var slotView = slots[i];
                var slotInfo = slotsInfo[i];
                
                var isEmpty = slotInfo.IsEmpty();
                slotView.SetHasIcon(!isEmpty);
                if (!isEmpty)
                {
                    var itemIcon = itemsConfig.GetItemSettings(slotInfo.Item).Icon;
                    slotView.SetIcon(itemIcon);
                }

                slotView.SetSelected(slotView.Id == currentSlot);
            }
        }
    }
}