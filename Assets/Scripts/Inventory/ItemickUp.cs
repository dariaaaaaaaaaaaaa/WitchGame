using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemickUp : MonoBehaviour
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
