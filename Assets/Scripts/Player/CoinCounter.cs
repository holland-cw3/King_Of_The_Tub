using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;


public class CoinCounter : MonoBehaviour, IDataPersistence
{
    public static CoinCounter instance;

    public TMP_Text coinText;

    private int currentCoins;

    void Awake()
    {
        instance = this;
    }

    public void LoadData(GameData data)
    {
        this.currentCoins = data.currentCoins;
    }

    public void SaveData(ref GameData data)
    {
        data.currentCoins = this.currentCoins;
    }




    void Start()
    {
        coinText.text = "" + currentCoins.ToString();
    }

    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;
        coinText.text = "" + currentCoins.ToString();
    }

    public int getCoins()
    {
        return currentCoins;
    }


}
