using System;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager Instance;

    public int Coins { get; private set; }

    public int coinsDevValue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadCoins()
    {
        Coins = PlayerPrefs.GetInt("coins", 0);

        if(coinsDevValue > 0)
        {
            Coins = coinsDevValue;
            SaveCoins();
        }
    }

    public void GetCoins(int amount)
    {
        Coins += amount;
        SaveCoins();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", Coins);
        PlayerPrefs.Save();
    }
}
