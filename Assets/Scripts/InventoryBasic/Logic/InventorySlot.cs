using System;
using Debug = Utils.Debug.Debug;

namespace InventoryBasic.Logic
{
    [Serializable]
    public class InventorySlot
    {
        private int _id;
        private int _itemId;

        public int Id => _id;
        public int ItemId => _itemId;

        
        public InventorySlot(int id, int itemId)
        {
            _id = id;
            _itemId = itemId;
        }
        
        public InventorySlot(int id)
        {
            _id = id;
            _itemId = InventoryUtils.NaNItemId;
        }
        public void PutItem(int id)
        {
            if (id < 0)
            {
                Debug.LogWarning(this, $"Put item id: {id} is invalid. Use DeleteItem();");
            }
            _itemId = id;
        }

        public void DeleteItem()
        {
            _itemId = InventoryUtils.NaNItemId;
        }

        public bool HasItem()
        {
            return _itemId == InventoryUtils.NaNItemId;
        }
        
        public bool HasItem(int itemId)
        {
            return _itemId == itemId;
        }
    }
}