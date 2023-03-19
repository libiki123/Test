using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalCoin;
    public int highScore;
    public string currentSkinId;
    public string currentThemeId;
    public SerializableDictionary<string, bool> itemPurchased;
    public GameSetting gameSetting;

    public GameData()
    {
        totalCoin = 0;
        highScore = 0;
        currentSkinId = "";
        currentThemeId = "";
        itemPurchased = new SerializableDictionary<string, bool>();
        gameSetting = new GameSetting();
    }
}

[System.Serializable]
public class GameSetting
{
    public bool muteMusic;
    public bool muteSFX;

    public GameSetting()
    {
        muteMusic = false;
        muteSFX = false;
    }
}
