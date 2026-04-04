using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float baseMaxHealth = 100.0f;
    private float lastMaxHealth;
    public float baseRegenHealthAmount = 0.1f;
    public float regenCooldown = 1.0f;

    public bool isPlayer = false;

    public bool isEnemy = false;

    public bool isBoss = false;

    public int killedEnemies = 0;

    public GameObject expItem;

    public UnityEvent<GameObject> OnHit, OnDeath;

    private bool isDead = false;
    private InGameUIManager gameOverScreen;
    private InGameUIManager victoryScreen;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI parametersHealthText;
    public TextMeshProUGUI parametersHealthRegenText;

    // public TextMeshProUGUI parametersHealthPauseText;
    // public TextMeshProUGUI parametersHealthRegenPauseText;

    public TextMeshProUGUI killedEnemiesText;

    public Slider healthBar;

    public PlayerStatsMultiplier statsMultiplier;

    private void Start()
    {
        UpgradesManager.Instance.SetUpgrades(this);

        // Wczytanie UI
        gameOverScreen = FindObjectOfType<InGameUIManager>();

        float maxHealth = GetFinalMaxHealth();
        health = maxHealth;
        lastMaxHealth = maxHealth;

        StartCoroutine(HealthRegen());
    }


    private void Update()
    {
        float currentMaxHealth = GetFinalMaxHealth();
        float finalRegenHealthAmount = GetFinalRegenHealthAmount();

        if(currentMaxHealth != lastMaxHealth)
        {
            CalculateHealth(currentMaxHealth);
        }

        // // Wartość slidera zdrowia = wartość zdrowia gracza
        healthBar.maxValue = currentMaxHealth;
        healthBar.value = health;

        // // Wartość slidera zdrowia = wartość zdrowia gracza
        // healthBar.GetComponent<Slider>().value = health;
        
        // Wartość zdrowia
        healthText.text = health.ToString("F2") + " / " + currentMaxHealth.ToString("F2");

        // Wartość zdrowia w panelu statystyk
        parametersHealthText.text = health.ToString("F2") + " / " + currentMaxHealth.ToString("F2");

        // Wartość regeneracji zdrowia w panelu statystyk
        parametersHealthRegenText.text = finalRegenHealthAmount.ToString("F2") + " na s";


        // // Wartość zdrowia w panelu pauzy
        // parametersHealthPauseText.text = "Zdrowie: " + health.ToString("F2") + " / " + maxHealth.ToString("F2");

        // // Wartość regeneracji zdrowia w panelu pauzy
        // parametersHealthRegenPauseText.text = "Regeneracja: " + regenHealthAmount.ToString("F2") + " na s";
    }

    // // Inicjujemy zdrowie obiektu
    // public void InitializeHealth(float healthValue)
    // {
    //     health = healthValue;
    //     maxHealth = healthValue;
    //     isDead = false;
    // }

    public float GetFinalMaxHealth()
    {
        return baseMaxHealth * statsMultiplier.healthMultiplier;
    }

    public float GetFinalRegenHealthAmount()
    {
        return baseRegenHealthAmount * statsMultiplier.healthRegenMultiplier;
    }

    public void CalculateHealth(float newMaxHealth)
    {
        float healthPercent = health / lastMaxHealth;

        health = newMaxHealth * healthPercent;

        lastMaxHealth = newMaxHealth;
    }

    // Metoda otrzymywania obrażeń
    public void GetHit(float damage, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer && !sender.CompareTag("BossAttack"))
            return;

        health -= damage;

        if (health <= 0)
        {
            OnDeath?.Invoke(sender);
            isDead = true;

            // Sprawdzenie czy obiekt to gracz
            if (isPlayer && gameOverScreen != null)
            {
                // Aktywowane UI końca gry
                gameOverScreen.GameOverScreen();
                Time.timeScale = 0;
                Destroy(gameObject);
            }
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }

    public void GetHealth(float amount)
    {
        health += amount;

        float maxHealth = GetFinalMaxHealth();
        
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private IEnumerator HealthRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenCooldown);

            float finalRegenHealth = GetFinalRegenHealthAmount();
            float maxHealth = GetFinalMaxHealth();

            if(health < maxHealth)
            {
                health += finalRegenHealth;

                if(health > maxHealth)
                {
                    health = maxHealth;
                }
            }
        }
    }

    public void AddMaxHealthBonus(float bonus)
    {
        baseMaxHealth += bonus;
    }

    public void AddRegenHealthBonus(float bonus)
    {
        baseRegenHealthAmount += bonus;
    }
}
