using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

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
    public TextMeshProUGUI killedEnemiesText;

    public GameObject healthBar;

    private void Start()
    {
        // Wczytanie UI
        gameOverScreen = FindObjectOfType<InGameUIManager>();
    }


    private void Update()
    {
        // Wartość slidera zdrowia = wartość zdrowia gracza
        healthBar.GetComponent<Slider>().value = health;
        
        // Wartość zdrowia
        healthText.text = health + " / " + maxHealth;
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
}
