using System.Collections.Generic;
using System.Linq;

namespace InventoryBasic.Logic
{
    public class InventoryHandler
    {
        private List<InventorySlot> _slots;

        public int SlotsCount => _slots.Count;

        public InventoryHandler(List<InventorySlot> slots)
        {
            _slots = slots;
        }
        
        public InventoryHandler(int slotsCount)
        {
            var slots = new List<InventorySlot>();
            for (var i = 0; i < slotsCount; i++)
            {
                slots.Add(new InventorySlot(i));
            }
            _slots = slots;
        }

        public void PutItem(int slotId, int itemId)
        {
            GetSlot(slotId).PutItem(itemId);
        }
        
        public void DeleteItem(int slotId)
        {
            GetSlot(slotId).DeleteItem();
        }

        public bool HasItem(int slotId)
        {
            return GetSlot(slotId).HasItem();
        }
        
        public bool HasItem(int slotId, int itemId)
        {
            return GetSlot(slotId).HasItem(itemId);
        }

        private InventorySlot GetSlot(int id)
        {
            return _slots.FirstOrDefault(s => s.Id == id);
        }
    }
}