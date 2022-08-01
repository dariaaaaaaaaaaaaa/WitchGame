using UnityEngine;

namespace InventoryBasic.Configs
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items/ItemSettings")]

    public class ItemSettings : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private string itemName;
        [SerializeField] private int value;
        [SerializeField] private Sprite icon;

        public int Id => id;
        public string ItemName => itemName;
        public int Value => value;
        public Sprite Icon => icon;
    }
}
