using System;
using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager Instance;

    public static event System.Action OnCoinsChanged;

    public int Coins { get; private set; }

    private int coinsDev = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (coinsDev >= 0)
        {
            SetCoins(coinsDev);
        }
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
        OnCoinsChanged?.Invoke();
    }

    public void GetCoins(int amount)
    {
        Coins += amount;
        SaveCoins();
        OnCoinsChanged?.Invoke();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", Coins);
        PlayerPrefs.Save();
    }

    public void SetCoins(int amount)
    {
        Coins = amount;
        SaveCoins();
        OnCoinsChanged?.Invoke();
    }

    [ContextMenu("+ 500 Monet")]
    public void AddCoins()
    {
        GetCoins(500);
    }
}
