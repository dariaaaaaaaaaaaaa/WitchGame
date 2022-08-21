using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory.Configs
{
    [CreateAssetMenu(fileName = "ItemsConfig", menuName = "Inventory/Items/Config", order = 0)]
    public class ItemsConfig : ScriptableObject
    {
        [SerializeField] private List<ItemInfo> items;

        public ItemInfo GetItemSettings(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }
        
        public ItemInfo GetItemSettings(ItemInfo item)
        {
            return items.FirstOrDefault(i => i.Id == item.Id);
        }
    }
}