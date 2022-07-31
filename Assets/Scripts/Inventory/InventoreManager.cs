using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoreManager : MonoBehaviour
{
    public static InventoreManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item Item)
    {
        Items.Add(Item);
    }

    public void Remove(Item Item)
    {
        Items.Remove(Item);
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
