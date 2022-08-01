using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventoryBasic.Configs
{
    [CreateAssetMenu(fileName = "ItemsConfig", menuName = "Inventory/Items/Config", order = 0)]
    public class ItemsConfig : ScriptableObject
    {
        [SerializeField] private List<ItemSettings> items;

        public ItemSettings GetItemSettings(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }
    }
}