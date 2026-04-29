using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsManager : MonoBehaviour
{
    public static GameSettingsManager Instance;

    public Map chosenMap;
    public Difficulty chosenDifficulty;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private string GetScoreKey(Map map, Difficulty difficulty)
    {
        return "Wynik: " + map + " " + difficulty;
    }

    public string GetScoreKey()
    {
        return GetScoreKey(chosenMap, chosenDifficulty);
    }

    public void SaveKilledEnemies(int killedEnemies)
    {
        string key = GetScoreKey();

        int bestScore = PlayerPrefs.GetInt(key, 0);

        if (killedEnemies > bestScore)
        {
            PlayerPrefs.SetInt(key, killedEnemies);
            PlayerPrefs.Save();
        }
    }

    public int GetKilledEnemies(Map map, Difficulty difficulty)
    {
        string key = GetScoreKey(map, difficulty);
        return PlayerPrefs.GetInt(key, 0);
    }
}
