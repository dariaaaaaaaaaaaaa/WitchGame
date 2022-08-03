using System;
using System.Collections.Generic;
using Core.DataStorage;
using Core.ManagersSystem;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class DataSaver : IManager, IDataSaveContainer
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        public void PutData(string key, object value)
        {
            if (!_data.ContainsKey(key))
            {
                _data.Add(key, value);
            }
            else
            {
                _data[key] = value;
            }
        }

        public void RemoveData(string key)
        {
            if (!_data.ContainsKey(key))
            {
                return;
            }

            _data.Remove(key);
        }

        public T GetData<T>(string key, T defaultValue = default)
        {
            return (T)(!_data.ContainsKey(key) ? defaultValue : _data[key]);
        }
        
        public object GetInstance()
        {
            return this;
        }
    }
}