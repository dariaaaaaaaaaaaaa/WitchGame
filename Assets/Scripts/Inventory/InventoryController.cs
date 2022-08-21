using System;
using System.Collections;
using Core.ManagersSystem;
using Inventory.Logic;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private float mouseSmoothness;
        
        private readonly ManagerReference<InventoryManager> _inventoryManager = new ManagerReference<InventoryManager>();


        private void Awake()
        {
            StartCoroutine(TrackCurrentItem());
        }

        private IEnumerator TrackCurrentItem()
        {
            var manager = _inventoryManager.Value;
            while (gameObject)
            {
                var mouseDelta = Input.mouseScrollDelta.y;
                if (Mathf.Abs(mouseDelta) > mouseSmoothness)
                {
                    var increment = (int) -Mathf.Sign(mouseDelta);
                    var nextCurrent = manager.CurrentSlot + increment;
                    if (nextCurrent < 0)
                    {
                        nextCurrent = manager.SlotsCount - 1;
                    } else if (nextCurrent >= manager.SlotsCount)
                    {
                        nextCurrent = 0;
                    }
                    manager.SetCurrentSlot(nextCurrent);
                }
                yield return null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                _inventoryManager.Value.DeleteItem(0); //TODO Remove after test
            }
        }
    }
}