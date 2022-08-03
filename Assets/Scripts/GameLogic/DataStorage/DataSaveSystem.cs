using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Core.ManagersSystem;
using Core.Utils;
using UnityEngine;

namespace Core.DataStorage
{
    public class DataSaveSystem : IDataSaveSystem, IManager
    {
        private readonly string _path;
        
        private DataStorage _storage;
        private readonly List<IDataSaveContainer> _dataSaveContainers = new List<IDataSaveContainer>();

        private bool _isWriting; // temp
        
        public DataSaveSystem()
        {
            _path = Path.Combine(Application.persistentDataPath, "data.dat");
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern void SyncFiles();
#endif
        
        
        public void Save()
        {
            UpdateStorage();
            WriteToFile();
        }

        private void UpdateStorage()
        {
            var storage = new DataStorage();
            foreach (var dataSaveContainer in _dataSaveContainers)
            {
                storage.containers.Add(dataSaveContainer.GetInstance());
            }

            _storage = storage;
        }

        public void Load()
        {
            if (!File.Exists(_path))
            {
                if (_storage == null)
                {
                    _storage = new DataStorage();
                }
                return;
            }
            
            ReadFromFile();
        }

        public T GetDataSaveContainer<T>()
        {
            foreach (var container in _storage.containers)
            {
                if (container.GetType() == typeof(T))
                {
                    return (T)container;
                }
            }

            return default;
        }

        public void AddSaveContainer(IDataSaveContainer dataSaveContainer)
        {
            _dataSaveContainers.Add(dataSaveContainer);
        }

        public void RemoveDataSaveContainer(IDataSaveContainer dataSaveContainer)
        {
            _dataSaveContainers.Remove(dataSaveContainer);
        }

        public void RemoveAll()
        {
            for (var index = 0; index < _dataSaveContainers.Count; index++)
            {
                _dataSaveContainers[index] = null;
            }

            _dataSaveContainers.Clear();
        }

        private void WriteToFile()
        {
            if (_isWriting)
            {
                Debug.Log("[WriteToFile] _isWriting = " + _isWriting);
                return;
            }
            Debug.Log("[WriteToFile] _path = " + _path);

            _isWriting = true;
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                var binaryArray = BinarySerializer.Serialize(_storage);
                fileStream.Write(binaryArray, 0, binaryArray.Length);
                _isWriting = false;
            }
            Debug.Log("[WriteToFile] Refresh file system");
#if UNITY_WEBGL && !UNITY_EDITOR
                SyncFiles();
#endif
        }

        private void ReadFromFile()
        {
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                _storage = BinarySerializer.Deserialize<DataStorage>(fileStream);
                Debug.Log("[ReadFromFile] deserialize");
            }
        }
    }
}