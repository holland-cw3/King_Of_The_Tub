using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentCoins;

    public Vector3 playerPosition;

    // default values for when the game starts with no data to load
    public GameData()
    {
        this.currentCoins = 0;
        playerPosition.x = -8.588f;
        playerPosition.y = -37.147f;


    }

}
