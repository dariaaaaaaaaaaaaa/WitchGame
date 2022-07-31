using UnityEngine;

namespace Inventory
{
    public class ItemPickUp : MonoBehaviour
    {
        public Item Item;

        public void PickUp()
        {
            InventoreManager.Instance.Add(Item);
            Destroy(gameObject);
        }

        private void OnMouseDown()
        {
            PickUp();
        }
    }
}
