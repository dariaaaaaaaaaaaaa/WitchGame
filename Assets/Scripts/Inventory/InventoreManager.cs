using System.Collections.Generic;
using InventoryBasic.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoreManager : MonoBehaviour
    {
        public static InventoreManager Instance;
        public List<ItemSettings> Items = new List<ItemSettings>();

        public Transform ItemContent;
        public GameObject InventoryItem;

        private void Awake()
        {
            Instance = this;
        }

        public void Add(ItemSettings itemSettings)
        {
            Items.Add(itemSettings);
        }

        public void Remove(ItemSettings itemSettings)
        {
            Items.Remove(itemSettings);
        }

        public void ListItems()
        {
            foreach(var Item in Items)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var ItemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
            }
        }
    }
}
