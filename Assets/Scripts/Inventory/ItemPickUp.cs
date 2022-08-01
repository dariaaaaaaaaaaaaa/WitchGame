using InventoryBasic.Configs;
using UnityEngine;

namespace Inventory
{
    public class ItemPickUp : MonoBehaviour
    {
        public ItemSettings itemSettings;

        public void PickUp()
        {
            InventoreManager.Instance.Add(itemSettings);
            Destroy(gameObject);
        }

        private void OnMouseDown()
        {
            PickUp();
        }
    }
}
