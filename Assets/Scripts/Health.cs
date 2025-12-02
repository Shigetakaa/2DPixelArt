using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float regenHealthAmount = 0.1f;
    public float regenCooldown = 1f;


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
    public TextMeshProUGUI parametersHealthRegenCooldownText;

    public TextMeshProUGUI parametersHealthPauseText;
    public TextMeshProUGUI parametersHealthRegenPauseText;
    public TextMeshProUGUI parametersHealthRegenCooldownPauseText;

    public TextMeshProUGUI killedEnemiesText;

    public GameObject healthBar;

    private void Start()
    {
        // Wczytanie UI
        gameOverScreen = FindObjectOfType<InGameUIManager>();

        StartCoroutine(HealthRegen());
    }


    private void Update()
    {
        // Wartość slidera zdrowia = wartość zdrowia gracza
        healthBar.GetComponent<Slider>().value = health;
        
        // Wartość zdrowia
        healthText.text = health.ToString("F2") + " / " + maxHealth.ToString("F2");

        // Wartość zdrowia w panelu statystyk
        parametersHealthText.text = "Zdrowie: " + health.ToString("F2") + " / " + maxHealth.ToString("F2");

        // Wartość regeneracji zdrowia w panelu statystyk
        parametersHealthRegenText.text = "Regeneracja: " + regenHealthAmount.ToString("F2");

        // Wartość regeneracji zdrowia w panelu statystyk
        parametersHealthRegenCooldownText.text = "Cooldown regeneracji: " + regenCooldown.ToString("F2");


        // Wartość zdrowia w panelu pauzy
        parametersHealthPauseText.text = "Zdrowie: " + health.ToString("F2") + " / " + maxHealth.ToString("F2");

        // Wartość regeneracji zdrowia w panelu pauzy
        parametersHealthRegenPauseText.text = "Regeneracja: " + regenHealthAmount.ToString("F2");

        // Wartość regeneracji zdrowia w panelu pauzy
        parametersHealthRegenCooldownPauseText.text = "Cooldown regeneracji: " + regenCooldown.ToString("F2");
    }

    // Inicjujemy zdrowie obiektu
    public void InitializeHealth(float healthValue)
    {
        health = healthValue;
        maxHealth = healthValue;
        isDead = false;
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

            if(health < maxHealth)
            {
                health += regenHealthAmount;
                if(health > maxHealth)
                {
                    health = maxHealth;
                }
            }
        }
    }
}
