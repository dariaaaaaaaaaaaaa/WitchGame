using Core.ManagersSystem;
using Inventory.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class GameInitialization : MonoBehaviour
    {
        [SerializeField] private string loadSceneName;
        private void Awake()
        {
            var inventoryManager = new InventoryManager(9);
            ManagersHolder.AddManager(inventoryManager);
            
            SceneManager.LoadScene(loadSceneName);
        }
    }
}
