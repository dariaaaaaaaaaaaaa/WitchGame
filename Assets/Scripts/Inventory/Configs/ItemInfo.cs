using UnityEngine;

namespace Inventory.Configs
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Items/ItemInfo")]

    public class ItemInfo : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private string itemName;
        [SerializeField] private int value;
        [SerializeField] private Sprite icon;

        public int Id => id;
        public string ItemName => itemName;
        public int Value => value;
        public Sprite Icon => icon;
        
        public bool Equals(ItemInfo item)
        {
            return item && item.id == id;
        }
    }
}
