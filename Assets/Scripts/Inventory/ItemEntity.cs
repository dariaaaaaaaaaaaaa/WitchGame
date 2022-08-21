using Core.ManagersSystem;
using Inventory.Configs;
using Inventory.Logic;
using Pointer;
using UnityEngine;

namespace Inventory
{
    public class ItemEntity : MonoBehaviour, IPlayerInteractable
    {
        [SerializeField] private ItemInfo info;

        private readonly ManagerReference<InventoryManager> _inventory = new ManagerReference<InventoryManager>();
        
        public int Id => info.Id;
        public void Interact()
        {
            _inventory.Value.AddItem(info, 1);
            gameObject.SetActive(false);
        }
    }
}