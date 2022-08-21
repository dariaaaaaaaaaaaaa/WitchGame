using Pointer;
using Time;
using UnityEngine;

namespace Interactables
{
    public class BedBehaviour : MonoBehaviour, IPlayerInteractable
    {
        public void Interact()
        {
            if (TimeManager.Instance.GetTime().Hour < 12)
            {
                return;
            }
            TimeManager.Instance.NextDay();
        }
    }
}