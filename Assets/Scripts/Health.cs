using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public bool isPlayer = false;

    public bool isEnemy = true;

    public GameObject expItem;

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
        if (sender.layer == gameObject.layer)
            return;

        health -= damage;

        if (health <= 0)
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

            // Sprawdzenie czy martwy obiekt to wróg
            if (isEnemy)
            {
                // Pojawia się doświadczenie po śmieci wroga
                Instantiate(expItem, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
