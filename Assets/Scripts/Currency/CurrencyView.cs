using System;
using Core.ManagersSystem;
using Currency.GameLogic;
using TMPro;
using UnityEngine;

namespace Currency
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private CurrencyTypes type;
        [SerializeField] private string format;
        [SerializeField] private TextMeshProUGUI label;

        private readonly ManagerReference<PlayerWallet> _wallet = new ManagerReference<PlayerWallet>();
        
        private void Awake()
        {
            _wallet.Value.OnWalletUpdated += RenderCurrency;
            RenderCurrency(type);
        }
        
        private void OnDestroy()
        {
            _wallet.Value.OnWalletUpdated -= RenderCurrency;

        }
        
        private void RenderCurrency(CurrencyTypes arg0)
        {
            label.text = string.Format(format, _wallet.Value.GetCurrency(type));
        }
        
    }
}