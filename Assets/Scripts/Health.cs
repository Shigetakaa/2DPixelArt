using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public bool isPlayer = false;

    public UnityEvent<GameObject> OnHit, OnDeath;

    private bool isDead = false;
    private InGameUIManager gameOverScreen;

    private void Start()
    {
        // Wczytanie UI końca gry
        gameOverScreen = FindObjectOfType<InGameUIManager>();
    }

    // Wartość slidera zdrowia = wartość zdrowia gracza
    private void Update()
    {
        GameObject.Find("HealthBar").GetComponent<Slider>().value = health;
    }

    // Inicjujemy zdrowie obiektu
    public void InitializeHealth(int healthValue)
    {
        health = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    // Metoda otrzymywania obrażeń
    public void GetHit(int damage, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        health -= damage;

        if (health < 0)
        {
            OnDeath?.Invoke(sender);
            isDead = true;

            // Sprawdzenie czy martwy obiekt to gracz
            if (isPlayer && gameOverScreen != null)
            {
                // Aktywowane UI końca gry
                gameOverScreen.GameOverScreen();
                Time.timeScale = 0;
            }

            Destroy(gameObject);
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
