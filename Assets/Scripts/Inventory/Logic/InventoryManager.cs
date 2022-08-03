using System;
using System.Collections.Generic;
using Core.ManagersSystem;
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
            _slots = new List<InventorySlot>(size);
            for (var i = 0; i < size; i++)
            {
                _slots.Add(new InventorySlot(i));
            }
        }

        public void SetCurrentSlot(int slotId)
        {
            if (slotId < 0 || slotId >= _slots.Count)
            {
                Debug.LogWarning(this, $"Slot {slotId} in not existing. Aborting");
                return;
            }
            
            _currentSlot = slotId;
            OnCurrentSlotChanged?.Invoke();
        }
        
    }
}