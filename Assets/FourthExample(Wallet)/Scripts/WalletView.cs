using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;

    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet) => _wallet = wallet;

    private void OnEnable()
    {
        _wallet.CoinsChanged += UpdateValue;

        UpdateValue(_wallet.Coins);
    }

    private void OnDisable()
    {
        _wallet.CoinsChanged -= UpdateValue;
    }

    private void UpdateValue(int coins) => _coins.text = coins.ToString();
}
