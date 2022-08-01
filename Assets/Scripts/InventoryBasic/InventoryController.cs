using System;
using System.Collections;
using InventoryBasic.Logic;
using UnityEngine;

namespace InventoryBasic
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private float mouseSmoothness;
        
        private InventoryManager _manager = InventoryManager.Instance;

        private void Awake()
        {
            StartCoroutine(TrackCurrentItem());
        }

        private IEnumerator TrackCurrentItem()
        {
            while (gameObject)
            {
                var mouseDelta = Input.mouseScrollDelta.y;
                if (Mathf.Abs(mouseDelta) > mouseSmoothness)
                {
                    var increment = (int) -Mathf.Sign(mouseDelta);
                    var nextCurrent = _manager.CurrentSlot + increment;
                    if (nextCurrent < 0)
                    {
                        nextCurrent = _manager.SlotsCount - 1;
                    } else if (nextCurrent >= _manager.SlotsCount)
                    {
                        nextCurrent = 0;
                    }
                    _manager.SetCurrentSlot(nextCurrent);
                }
                yield return null;
            }
        }
    }
}