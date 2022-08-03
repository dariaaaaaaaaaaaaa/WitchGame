using System;
using System.Collections.Generic;
using System.Numerics;
using Core.DataStorage;
using UnityEngine;

namespace Core.Wallet
{
    [Serializable]
    public class Wallet<T> : IWallet<T>, IDataSaveContainer
    {
        private readonly Dictionary<T, int> _wallet = new Dictionary<T, int>();

        [NonSerialized]
        public  Action<T> OnWalletUpdated;
        
        public int GetCurrency(T type)
        {
            CheckCurrencyExistence(type);
            return _wallet[type];
        }

        public void SetCurrency(T type, int value)
        {
            CheckCurrencyExistence(type);
            _wallet[type] = value;
            OnWalletUpdated?.Invoke(type);
        }

        public void IncreaseCurrency(T type, int value)
        {
            CheckCurrencyExistence(type);
            _wallet[type] += value;
            OnWalletUpdated?.Invoke(type);
        }

        public void DecreaseCurrency(T type, int value)
        {
            CheckCurrencyExistence(type);
            _wallet[type] -= value;
            OnWalletUpdated?.Invoke(type);
        }

        private void CheckCurrencyExistence(T type)
        {
            if (!_wallet.ContainsKey(type))
            {
                _wallet.Add(type, 0);
            }
        }

        public object GetInstance()
        {
            return this;
        }
    }
}