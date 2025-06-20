using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;

    private int MAX_HEALTH = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int damage)
    {
        if (damage < 0)
        {
            throw new System.ArgumentOutOfRangeException("Nie można miec ujemnych obrażeń");
        }

        this.health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        if (heal < 0)
        {
            throw new System.ArgumentOutOfRangeException("Nie można mieć ujemnego leczenia");
        }

        bool OverMaxHealth = health + heal > MAX_HEALTH;

        if (OverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += heal;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
