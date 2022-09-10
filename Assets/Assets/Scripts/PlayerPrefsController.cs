using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsController
{

    public static void SavePlayerInfo()
    {
        PlayerPrefs.SetFloat("playerHealth", GameManager.Instance.playerController.currentHealth);
        PlayerPrefs.SetInt("playerCoin", GameManager.Instance.playerController.coin);
    }

    public static void SaveGlobalPrefs()
    {
        PlayerPrefs.SetString("Language", GameManager.Instance.gameLanguage.ToString());
    }

    public static Dictionary<string, float> GetPlayerInfo()
    {
        Dictionary<string, float> playerInfoDict = new Dictionary<string, float>();
        playerInfoDict.Add("health", PlayerPrefs.GetFloat("playerHealth"));
        playerInfoDict.Add("coin", PlayerPrefs.GetInt("playerCoin"));

        return playerInfoDict;
    }

    public static Dictionary<string, string> GetGlobalPrefs()
    {
        Dictionary<string, string> globalInfoDict = new Dictionary<string, string>();
        globalInfoDict.Add("language", PlayerPrefs.GetString("Language", GameManager.Instance.gameLanguage.ToString()));
        return globalInfoDict;
    }
}
