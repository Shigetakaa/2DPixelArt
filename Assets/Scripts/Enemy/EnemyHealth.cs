using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 10f;
    public float maxEnemyHealth = 10f;

    public int killedEnemies = 0;

    private bool isDead = false;

    public GameObject expItem;
    public GameObject coinItem;

    public UnityEvent<GameObject> OnHit, OnDeath;

    public TextMeshProUGUI killedEnemiesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetDifficulty();
    }

    public void GetDifficulty()
    {
        switch (GameSettingsManager.Instance.chosenDifficulty)
        {
            case Difficulty.Easy:
                enemyHealth = 10f;
                maxEnemyHealth = 10f;
                break;
            case Difficulty.Normal:
                enemyHealth = 20f;
                maxEnemyHealth = 20f;
                break;
            case Difficulty.Hard:
                enemyHealth = 40f;
                maxEnemyHealth = 40f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Inicjujemy zdrowie obiektu
    public void InitializeHealth(float healthValue)
    {
        enemyHealth = healthValue;
        maxEnemyHealth = healthValue;
        isDead = false;
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
            Instantiate(coinItem, transform.position, Quaternion.identity);

            Destroy(gameObject);

            // Ilość pokonanych wrogów
            Health player = sender.GetComponent<Health>();
            if (player != null && player.isPlayer)
            {
                player.killedEnemies++;
                if (player.killedEnemiesText != null)
                {
                    player.killedEnemiesText.text = "Pokonani wrogowie: " + player.killedEnemies;
                }
            }
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
