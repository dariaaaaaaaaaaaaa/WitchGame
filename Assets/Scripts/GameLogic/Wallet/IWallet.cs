using System.Numerics;
using Core.ManagersSystem;

namespace Core.Wallet
{
    public interface IWallet<T> : IManager
    {
        int GetCurrency(T type);
        void SetCurrency(T type, int value);
        
        void IncreaseCurrency(T type, int value);
        void DecreaseCurrency(T type, int value);
    }
}