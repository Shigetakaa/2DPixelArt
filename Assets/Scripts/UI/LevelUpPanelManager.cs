using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUpPanelManager : MonoBehaviour
{
    public GameObject levelUpScreen;

    public GameObject characterStats;

    public WeaponParent weaponParent;
    public Health health;
    public Exp exp;
    public Controller player;

    // public List<Button> buttons;

    public List<StatPerk> perks;
    public List<StatPerk> currrentPerks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // perks = new List<StatPerk>()
        // {
        //     new StatPerk("Zwiększ zdrowie +5", () =>
        //     {
        //         health.maxHealth += 5f;
        //         health.health += 5f;
        //     }),
        //     new StatPerk("Zwiększ atak +1", () =>
        //     {
        //         weaponParent.playerDamage += 1f;
        //     }),
        //     new StatPerk("Zwiększ regeneracje zdrowie +0.2", () =>
        //     {
        //         health.regenHealthAmount += 0.2f;
        //     }),
        //     new StatPerk("Zmniejsz czas odnowienia ataku -0.05s", () =>
        //     {
        //         weaponParent.cooldown -= 0.05f;
        //     }),
        //     new StatPerk("Zwiększ prędkość ruchu +0.5", () =>
        //     {
        //         player.moveSpeed += 0.5f;
        //     })
        // };

        currrentPerks = new List<StatPerk>(perks);
    }

    public List<StatPerk> GetRandomPerks()
    {
        return currrentPerks
            .OrderBy(x => Random.value)
            .Take(3)
            .ToList();
    }

    public void ApplyPerk(StatPerk perk)
    {
        switch (perk.perkType)
        {
            case PerkType.MaxHealth:
                health.maxHealth += perk.perkValue;
                health.health += perk.perkValue;
                break;
            
            case PerkType.Damage:
                weaponParent.playerDamage += perk.perkValue;
                break;

            case PerkType.HealthRegen:
                health.regenHealthAmount += perk.perkValue;
                break;
            
            case PerkType.Cooldown:
                weaponParent.cooldown -= perk.perkValue;
                break;

            case PerkType.MoveSpeed:
                player.moveSpeed += perk.perkValue;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void ShowRandomButtons()
    // {
    //     foreach (Button button in buttons)
    //     {
    //         button.gameObject.SetActive(false);
    //     }

    //     List<Button> temp = new List<Button>(buttons);

    //     for (int i=0; i<3; i++)
    //     {
    //         int random = Random.Range(0, temp.Count);
    //         temp[random].gameObject.SetActive(true);
    //         temp.RemoveAt(random);
    //     }
    // }

    // // Metoda zwiększąjąca atak postaci
    // public void OnAttackPress()
    // {
    //     weaponParent.playerDamage += 1f;
    //     levelUpScreen.SetActive(false);
    //     characterStats.SetActive(true);
    //     Time.timeScale = 1;
    // }

    // // Metoda zwiększąjąca zdrowie postaci
    // public void OnHealtPress()
    // {
    //     health.maxHealth += 5f;
    //     health.health += 5f;
    //     levelUpScreen.SetActive(false);
    //     characterStats.SetActive(true);
    //     Time.timeScale = 1;
    // }

    // // Metoda zwiększająca regeneracje zdrowia postaci
    // public void OnRegenHealthPress()
    // {
    //     health.regenHealthAmount += 0.2f;
    //     levelUpScreen.SetActive(false);
    //     characterStats.SetActive(true);
    //     Time.timeScale = 1;
    // }

    // // Metoda zwiększąjąca prędkość ruchu postaci  
    // public void OnMoveSpeedPress()
    // {
    //     player.moveSpeed += 0.5f;
    //     levelUpScreen.SetActive(false);
    //     characterStats.SetActive(true);
    //     Time.timeScale = 1;
    // }

    // // Metoda zmiejszająca cooldown ataku
    // public void OnAttackCooldownPress()
    // {
    //     weaponParent.cooldown -= 0.05f;
    //     levelUpScreen.SetActive(false);
    //     characterStats.SetActive(true);
    //     Time.timeScale = 1;
    // }

    // // Metoda zmiejszająca cooldown regeneracji zdrowia
    // public void OnRegenHealthCooldownPress()
    // {
    //     health.regenCooldown -= 0.1f;
    //     levelUpScreen.SetActive(false);
    //     characterStats.SetActive(true);
    //     Time.timeScale = 1;
    // }
}
