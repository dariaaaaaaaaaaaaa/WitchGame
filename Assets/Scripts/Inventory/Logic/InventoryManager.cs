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

        public event Action OnUpdated;
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
            OnUpdated?.Invoke();
            OnCurrentSlotChanged?.Invoke();
        }

        public void AddItem(ItemInfo item, int quantity)
        {
            if (FirstSlot(item) == default && !HasEmptySlot())
            {
                Debug.LogWarning(this, "No empty slots to add. Aborting");
                return;
            }

            UnityEngine.Debug.Log("Add" + item.ItemName);
            AddItem(item, FirstEmptySlot(), quantity);
            OnUpdated?.Invoke();
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
            OnUpdated?.Invoke();
        }

        private void AddItem(ItemInfo item, InventorySlot slot, int quantity)
        {
            slot.PutItems(item, quantity);
        }

        public void DeleteItem(ItemInfo item)
        {
            FirstSlot(item).DeleteItem();
            OnUpdated?.Invoke();
        }

        public void DeleteItem(int slotId)
        {
            GetSlot(slotId).DeleteItem();
            OnUpdated?.Invoke();
        }

        public SlotInfo GetSlotInfo(int slotId)
        {
            var slot = GetSlot(slotId);
            return new SlotInfo(slot);
        }
        
        public List<SlotInfo> GetSlotsInfo()
        {
            return _slots.Select(s => new SlotInfo(s)).ToList();
        }

        public bool HasItem(ItemInfo item, int quantity)
        {
            var itemSlot = FirstSlot(item);
            return itemSlot != default && itemSlot.Quantity >= quantity;
        }

        private bool HasEmptySlot()
        {
            return FirstEmptySlot() != default;
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

    public class SlotInfo
    {
        private InventorySlot _slot;

        public int Id => _slot.Id;
        public ItemInfo Item => _slot.Item;
        public int Quantity => _slot.Quantity;

        public bool IsEmpty()
        {
            return !_slot.HasItem();
        }

        public SlotInfo(InventorySlot slot)
        {
            _slot = slot;
        }
    }
}