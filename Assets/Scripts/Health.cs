using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public UnityEvent<GameObject> OnHit, OnDeath;

    private bool isDead = false;

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
            Destroy(gameObject);
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
