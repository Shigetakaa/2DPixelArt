using TMPro;
using UnityEngine;

public class LevelUpPanelManager : MonoBehaviour
{
    public GameObject levelUpScreen;

    public GameObject characterStats;

    public WeaponParent weaponParent;
    public Health health;
    public Exp exp;
    public Controller player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Metoda zwiększąjąca atak postaci
    public void OnAttackPress()
    {
        weaponParent.playerDamage += 1f;
        levelUpScreen.SetActive(false);
        characterStats.SetActive(true);
        Time.timeScale = 1;
    }

    // Metoda zwiększąjąca zdrowie postaci
    public void OnHealtPress()
    {
        health.maxHealth += 5f;
        health.health += 5f;
        levelUpScreen.SetActive(false);
        characterStats.SetActive(true);
        Time.timeScale = 1;
    }

    // Metoda zwiększająca regeneracje zdrowia postaci
    public void OnRegenHealthPress()
    {
        health.regenHealthAmount += 0.2f;
        levelUpScreen.SetActive(false);
        characterStats.SetActive(true);
        Time.timeScale = 1;
    }

    // Metoda zwiększąjąca prędkość ruchu postaci  
    public void OnMoveSpeedPress()
    {
        player.moveSpeed += 0.5f;
        levelUpScreen.SetActive(false);
        characterStats.SetActive(true);
        Time.timeScale = 1;
    }

    // Metoda zmiejszająca cooldown ataku
    public void OnAttackCooldownPress()
    {
        weaponParent.cooldown -= 0.1f;
        levelUpScreen.SetActive(false);
        characterStats.SetActive(true);
        Time.timeScale = 1;
    }

    // Metoda zmiejszająca cooldown regeneracji zdrowia
    public void OnRegenHealthCooldownPress()
    {
        health.regenCooldown -= 0.1f;
        levelUpScreen.SetActive(false);
        characterStats.SetActive(true);
        Time.timeScale = 1;
    }
}
