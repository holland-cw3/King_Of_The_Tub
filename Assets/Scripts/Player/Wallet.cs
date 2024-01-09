using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour, IDataPersistence
{
    public TMP_Text coinText;
    private int currentCoins;
    public int amount;

   
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
    }

    public void LoadData(GameData data)
    {
        this.currentCoins = data.currentCoins;
    }

    public void SaveData(ref GameData data)
    {
        data.currentCoins = this.currentCoins;
    }

    public void DecreaseCoins(int amount)
    {
        if (!(currentCoins - amount < 0))
        {
            currentCoins -= amount;
            coinText.text = "Coins: " + currentCoins.ToString();
        }

    }

}
