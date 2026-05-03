using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float bossHealth;
    public float baseMaxBossHealth = 100f;
    private float lastMaxHealth;

    public UnityEvent<GameObject> OnHit, OnDeath;

    public Slider healthBar;

    public SpriteRenderer sprite;
    private Coroutine flashCoroutine;
    public float flashTime = 0.1f;
    private Color originalColor;

    private bool isDead = false;

    private InGameUIManager victoryScreen;

    public PlayerStatsMultiplier statsMultiplier;
    private Health player;

    public AudioClip[] damageSound;
    public AudioClip victorySound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        statsMultiplier = GameObject.FindWithTag("Player").GetComponent<PlayerStatsMultiplier>();
        healthBar = GameObject.Find("BossHealthBar").GetComponent<Slider>();
        GameObject playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Health>();

        originalColor = sprite.color;

        GetDifficulty();

        float maxHealth = GetFinalMaxHealth();
        bossHealth = maxHealth;
        lastMaxHealth = maxHealth;

        // Wczytanie UI
        victoryScreen = FindObjectOfType<InGameUIManager>();
    }

    public void GetDifficulty()
    {
        switch (GameSettingsManager.Instance.chosenDifficulty)
        {
            case Difficulty.Easy:
                baseMaxBossHealth = 100.0f;
                break;

            case Difficulty.Normal:
                baseMaxBossHealth = 200.0f;
                break;

            case Difficulty.Hard:
                baseMaxBossHealth = 400.0f;
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

        // Slider dla bossa
        healthBar.maxValue = currentMaxHealth;
        healthBar.value = bossHealth;
    }

    public float GetFinalMaxHealth()
    {
        return baseMaxBossHealth * statsMultiplier.difficultyMultiplier;
    }

    public void CalculateHealth(float newMaxHealth)
    {
        float healthPercent = bossHealth / lastMaxHealth;

        bossHealth = newMaxHealth * healthPercent;

        lastMaxHealth = newMaxHealth;
    }

    // Metoda otrzymywania obrażeń
    public void GetHit(float damage, GameObject sender)
    {
        if (isDead)
        {
            return;
        }
        if (sender.layer == gameObject.layer)
        {
            return;
        }

        bossHealth -= damage;

        if(bossHealth <= 0 && !isDead)
        {
            isDead = true;

            OnDeath?.Invoke(sender);

            SoundManager.instance.PlaySound(victorySound, transform, 1f);

            if(player != null)
            {
                GameSettingsManager.Instance.SaveKilledEnemies(player.killedEnemies);
                CoinsManager.Instance.GetCoins(player.coins);

                if(victoryScreen != null)
                {
                    victoryScreen.VictoryScreen(player.killedEnemies);
                }
            }

            Destroy(gameObject);
        }
        else
        {
            OnHit?.Invoke(sender);
            PlayFlash();

            SoundManager.instance.PlayRandomSounds(damageSound, transform, 1f);
        }
    }

    private void PlayFlash()
    {
        if(flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        sprite.color = new Color(255, 250, 240, 255);
        yield return new WaitForSeconds(flashTime);
        sprite.color = originalColor;
    }
}
