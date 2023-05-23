using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void UpdateUI()
    {
        UIInGameManager.UpdateTextCoins(coins.ToString());
        // uiTextCoins.text = coins.ToString();
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amout = 1)
    {
        coins.value += amout;        
        UpdateUI();
    }
}
