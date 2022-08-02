using InventoryBasic.Configs;
using UnityEngine;

namespace InventoryBasic
{
    public class ItemEntity : MonoBehaviour
    {
        [SerializeField] private ItemInfo info;

        public int Id => info.Id;
    }
}