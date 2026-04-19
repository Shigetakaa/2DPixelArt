using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float baseMaxEnemyHealth = 10f;
    private float lastMaxHealth;

    public int killedEnemies = 0;

    private bool isDead = false;

    public GameObject expItem;

    public UnityEvent<GameObject> OnHit, OnDeath;

    public TextMeshProUGUI killedEnemiesText;

    private PlayerStatsMultiplier statsMultiplier;

    public int minCoinAmount = 1;
    public int maxCoinsAmount = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        statsMultiplier = GameObject.FindWithTag("Player").GetComponent<PlayerStatsMultiplier>();

        GetDifficulty();

        float maxHealth = GetFinalMaxHealth();
        enemyHealth = maxHealth;
        lastMaxHealth = maxHealth;
    }

    public void GetDifficulty()
    {
        switch (GameSettingsManager.Instance.chosenDifficulty)
        {
            case Difficulty.Easy:
                baseMaxEnemyHealth = 10.0f;
                break;

            case Difficulty.Normal:
                baseMaxEnemyHealth = 20.0f;
                break;

            case Difficulty.Hard:
                baseMaxEnemyHealth = 40.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentMaxHealth = GetFinalMaxHealth();

        if(currentMaxHealth != lastMaxHealth)
        {
            CalculateHealth(currentMaxHealth);
        }
    }

    public float GetFinalMaxHealth()
    {
        return baseMaxEnemyHealth * statsMultiplier.difficultyMultiplier;
    }

    public void CalculateHealth(float newMaxHealth)
    {
        float healthPercent = enemyHealth / lastMaxHealth;

        enemyHealth = newMaxHealth * healthPercent;

        lastMaxHealth = newMaxHealth;
    }

    // Metoda otrzymywania obrażeń
    public void GetHit(float damage, GameObject sender)
    {
        if(isDead)
            return;
        if(sender.layer == gameObject.layer)
            return;

        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            OnDeath?.Invoke(sender);
            isDead = true;

            // Pojawia się doświadczenie i moneta po śmierci wroga
            Instantiate(expItem, transform.position, Quaternion.identity);
            // Instantiate(coinItem, transform.position, Quaternion.identity);

            Destroy(gameObject);

            // Ilość pokonanych wrogów
            Health player = sender.GetComponent<Health>();
            if (player != null && player.isPlayer)
            {
                int randomCoinAmount = UnityEngine.Random.Range(minCoinAmount, maxCoinsAmount);
                player.GetInGameCoins(randomCoinAmount);

                player.killedEnemies++;
                if (player.killedEnemiesText != null)
                {
                    player.killedEnemiesText.text = player.killedEnemies.ToString();
                }
            }
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
