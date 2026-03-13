using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float bossHealth = 100f;
    public float maxBossHealth = 100f;

    public UnityEvent<GameObject> OnHit, OnDeath;

    private bool isDead = false;

    private InGameUIManager victoryScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetDifficulty();

        // Wczytanie UI
        victoryScreen = FindObjectOfType<InGameUIManager>();
    }

    public void GetDifficulty()
    {
        switch (GameSettingsManager.Instance.chosenDifficulty)
        {
            case Difficulty.Easy:
                bossHealth = 100f;
                maxBossHealth = 100f;
                break;
            case Difficulty.Normal:
                bossHealth = 200f;
                maxBossHealth = 200f;
                break;
            case Difficulty.Hard:
                bossHealth = 400f;
                maxBossHealth = 400f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Slider dla bossa
        GameObject.Find("BossHealthBar").GetComponent<Slider>().value = bossHealth;
    }

    // Inicjujemy zdrowie obiektu
    public void InitializeHealth(float healthValue)
    {
        bossHealth = healthValue;
        maxBossHealth = healthValue;
        isDead = false;
    }

    // Metoda otrzymywania obrażeń
    public void GetHit(float damage, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        bossHealth -= damage;

        if(bossHealth <= 0)
        {
            OnDeath?.Invoke(sender);
            isDead = true;

            Health player = sender.GetComponent<Health>();
            if(player != null)
            {
                GameSettingsManager.Instance.SaveKilledEnemies(player.killedEnemies);

                victoryScreen.VictoryScreen(player.killedEnemies);
            }

            Destroy(gameObject);
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
