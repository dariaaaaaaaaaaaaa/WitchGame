using Inventory.Configs;
using UnityEngine;

namespace Inventory
{
    public class ItemEntity : MonoBehaviour
    {
        [SerializeField] private ItemInfo info;

        public int Id => info.Id;
    }
}