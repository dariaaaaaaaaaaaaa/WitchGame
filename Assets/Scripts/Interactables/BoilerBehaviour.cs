using System;
using System.Collections.Generic;
using Core.ManagersSystem;
using Inventory.Configs;
using Inventory.Logic;
using Pointer;
using UnityEngine;

namespace Interactables
{
    public class BoilerBehaviour : MonoBehaviour, IPlayerInteractable
    {
        [SerializeField] private List<BoilerCookRecipe> recipes;

        private readonly List<ItemInfo> _items = new List<ItemInfo>();

        private readonly ManagerReference<InventoryManager>
            _inventoryManager = new ManagerReference<InventoryManager>();

        public void Interact()
        {
            var currentSlotId = _inventoryManager.Value.CurrentSlot;
            var currentSlot = _inventoryManager.Value.GetSlotInfo(currentSlotId);
            if (currentSlot.IsEmpty() || _items.Contains(currentSlot.Item))
            {
                return;
            }

            _items.Add(currentSlot.Item);
            _inventoryManager.Value.DeleteItem(currentSlotId);

            foreach (var recipe in recipes)
            {
                if (!recipe.CheckRecipe(_items))
                {
                    continue;
                }

                _inventoryManager.Value.AddItem(recipe.ResultItem, 1);
                _items.Clear();
                break;
            }
        }
    }

    [Serializable]
    public class BoilerCookRecipe
    {
        [SerializeField] private List<ItemInfo> requiredItems;
        [SerializeField] private ItemInfo resultItem;

        public List<ItemInfo> RequiredItems => requiredItems;
        public ItemInfo ResultItem => resultItem;

        public bool CheckRecipe(List<ItemInfo> items)
        {
            var itemsRequired = requiredItems.Count;
            var hasRequiredItems = 0;
            foreach (var item in items)
            {
                if (requiredItems.Contains(item)) hasRequiredItems++;
            }

            return itemsRequired <= hasRequiredItems;
        }
    }
}