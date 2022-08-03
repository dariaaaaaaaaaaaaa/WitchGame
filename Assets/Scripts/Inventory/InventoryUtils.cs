using System.Collections.Generic;
using System.Net.Http.Headers;
using Inventory.Logic;

namespace Inventory
{
    public static class InventoryUtils
    {
        public static List<InventorySlot> CreateDefaultInventory(int size)
        {
            var slots = new List<InventorySlot>();
            for (var i = 0; i < size; i++)
            {
                slots.Add(new InventorySlot(i));
            }

            return slots;
        }
    }
}