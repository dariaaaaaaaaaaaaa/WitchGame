using System;
using Inventory.Configs;

namespace Inventory.Logic
{
    [Serializable]
    public class InventorySlot
    {
        private int _id;
        private ItemInfo _item;
        private int _quantity;

        public int Id => _id;
        public ItemInfo Item => _item;
        public int Quantity => _quantity;

        public InventorySlot(int id, ItemInfo item, int quantity)
        {
            _id = id;
            _item = item;
            _quantity = quantity;
        }

        public InventorySlot(int id)
        {
            _id = id;
            _item = null;
        }

        public void PutItem(ItemInfo item)
        {
            if (_item && !item.Equals(item))
            {
                throw new ArgumentException("Item already exists and has different id");
            }

            if (_item)
            {
                _quantity++;
                return;
            }

            _item = item;
            _quantity++;
        }
        
        public void PutItems(ItemInfo item, int quantity)
        {
            if (_item && !item.Equals(item))
            {
                throw new ArgumentException("Item already exists and has different id");
            }

            if (_item)
            {
                _quantity += quantity;
                return;
            }

            _item = item;
            _quantity += quantity;
        }
        

        public void DeleteItem()
        {
            if (_item == null)
            {
                throw new Exception("Can't delete item that doesn't exist");
            }
            if (_quantity > 1)
            {
                _quantity--;
                return;
            }

            _quantity = 0;
            _item = null;
        }

        public void DeleteItems(int quantity)
        {
            if (_item == null)
            {
                throw new Exception("Can't delete item that doesn't exist");
            }
            if (quantity > _quantity)
            {
                throw new ArgumentOutOfRangeException($"Quantity {quantity} is more that slot have {_quantity}");
            }

            _quantity -= quantity;
            if (_quantity <= 0)
            {
                _item = null;
            }
        }

        public bool HasItem()
        {
            return _item != null;
        }
        
        public bool HasItem(ItemInfo item)
        {
            return _item && _item.Equals(item);
        }
    }
}