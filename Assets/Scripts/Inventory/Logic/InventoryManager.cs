using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Core.ManagersSystem;
using Inventory.Configs;
using Utils.Debug;

namespace Inventory.Logic
{
    public class InventoryManager : IManager
    {

        private int _currentSlot;
        private List<InventorySlot> _slots;

        public int CurrentSlot => _currentSlot;
        public int SlotsCount => _slots.Count;

        public event Action OnCurrentSlotChanged;

        public InventoryManager(int size)
        {
            _slots = InventoryUtils.CreateDefaultInventory(size);
        }

        public void SetCurrentSlot(int slotId)
        {
            if (!CheckValidSlotId(slotId))
            {
                return;
            }
            
            _currentSlot = slotId;
            OnCurrentSlotChanged?.Invoke();
        }

        public void AddItem(ItemInfo item, int quantity)
        {
            if (FirstSlot(item) == default && !HasEmptySlot())
            {
                Debug.LogWarning(this, "No empty slots to add. Aborting");
                return;
            }
            AddItem(item, FirstEmptySlot(), quantity);
        }
        
        public void AddItemToSlot(ItemInfo item, int slotId, int quantity = 1)
        {
            if (!CheckValidSlotId(slotId))
            {
                return;
            }

            var slot = GetSlot(slotId);
            if (slot.HasItem() && !slot.HasItem(item))
            {
                Debug.LogWarning(this, $"Trying to add wrong item type {item.Id}. Aborting");
                return;
            }
            AddItem(item, slot, quantity);
        }

        private void AddItem(ItemInfo item, InventorySlot slot, int quantity)
        {
            slot.PutItems(item, quantity);
        }

        private bool HasEmptySlot()
        {
            return FirstEmptySlot() == default;
        }

        private InventorySlot FirstEmptySlot()
        {
            return _slots.FirstOrDefault(slot => !slot.HasItem());
        }
        
        private InventorySlot FirstSlot(ItemInfo item)
        {
            return _slots.FirstOrDefault(slot => slot.HasItem() && item.Equals(slot.Item));
        }

        private InventorySlot GetSlot(int slotId)
        {
            return _slots.FirstOrDefault(slot => slot.Id == slotId);
        }
        
        private bool CheckValidSlotId(int slotId)
        {
            if (IsValidSlotId(slotId))
            {
                return true;
            }
            Debug.LogWarning(this, $"Slot {slotId} in non existing. Aborting");
            return false;
        }

        private bool IsValidSlotId(int slotId)
        {
            return slotId >= 0 && slotId < SlotsCount;
        }
        
    }
}