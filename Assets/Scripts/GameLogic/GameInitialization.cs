using Core.ManagersSystem;
using Currency.GameLogic;
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
            var wallet = new PlayerWallet();
            ManagersHolder.AddManager(wallet);
            
            var inventoryManager = new InventoryManager(9);
            ManagersHolder.AddManager(inventoryManager);
            
            SceneManager.LoadScene(loadSceneName);
        }
    }
}
