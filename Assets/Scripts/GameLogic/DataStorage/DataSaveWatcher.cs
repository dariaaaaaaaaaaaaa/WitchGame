// using System;
// using System.Collections;
// using Core.ManagersSystem;
// using Experience;
// using UnityEngine;
// using Wallet;
//
// namespace Core.DataStorage
// {
//     public class DataSaveWatcher : MonoBehaviour, IManager
//     {
//         private const float UpdateTimer = 5f;
//         
//         private readonly ManagerReference<DataSaveSystem> _dataSaveSystem = new ManagerReference<DataSaveSystem>();
//         private readonly ManagerReference<PlayerWallet> _wallet = new ManagerReference<PlayerWallet>();
//         private readonly ManagerReference<ExperienceManager> _experienceManager = new ManagerReference<ExperienceManager>();
//
//         private bool _saveRequired;
//         private bool _isSaved;
//         
//         private void OnEnable()
//         {
//             _wallet.Value.WalletUpdated += OnValueWalletUpdated;
//             _experienceManager.Value.WalletUpdated += OnExperienceUpdated;
//             StartCoroutine(UpdateSave());
//         }
//
//         private void Start()
//         {
//             ForceSave();
//         }
//
//         private void LateUpdate()
//         {
//             if (_saveRequired)
//             {
//                 _saveRequired = false;
//                 _dataSaveSystem.Value.Save();
//             }
//         }
//
//         public void ForceSave()
//         {
//             _saveRequired = true;
//         }
//
//         private void OnValueWalletUpdated(WalletTypes type)
//         {
//             ForceSave();
//         }
//
//         private void OnExperienceUpdated(LevelSystemTypes type)
//         {
//             ForceSave();
//         }
//
//
//         private IEnumerator UpdateSave()
//         {
//             while (true)
//             {
//                 yield return new WaitForSeconds(UpdateTimer);
//                 ForceSave();
//             }
//         }
//     }
// }