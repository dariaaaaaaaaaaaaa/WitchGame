using System;
using Utils.Debug;

namespace InventoryBasic.Logic
{
    public class InventoryManager
    {
        private static InventoryManager _instance;

        public static InventoryManager Instance
        {
            get { return _instance ??= new InventoryManager(); }
        }

        private InventoryHandler _inventoryHandler;
        private int _currentSlot;

        public int CurrentSlot => _currentSlot;
        public int SlotsCount => _inventoryHandler.SlotsCount;

        public event Action OnCurrentSlotChanged;

        private InventoryManager()
        {
            _inventoryHandler = new InventoryHandler(9); //TODO ManagerReference :(
        }

        public void SetCurrentSlot(int slotId)
        {
            if (slotId < 0 || slotId >= _inventoryHandler.SlotsCount)
            {
                Debug.LogWarning(this, $"Slot {slotId} in not existing. Aborting");
                return;
            }
            
            _currentSlot = slotId;
            OnCurrentSlotChanged?.Invoke();
        }

        /*public int PutItem(int slotId)
        {
            return _inventoryHandler.
        }*/
    }
}