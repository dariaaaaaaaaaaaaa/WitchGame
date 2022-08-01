using InventoryBasic.Configs;
using UnityEngine;

namespace InventoryBasic
{
    public class ItemEntity : MonoBehaviour
    {
        [SerializeField] private ItemSettings settings;

        public int Id => settings.Id;
    }
}