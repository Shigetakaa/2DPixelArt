using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUpPanelManager : MonoBehaviour
{
    public GameObject levelUpScreen;

    public GameObject characterStats;

    public PlayerStatsMultiplier statsMultiplier;

    public List<StatPerk> perks;
    public List<StatPerk> currrentPerks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // currrentPerks = new List<StatPerk>(perks);
    }

    public List<StatPerk> GetRandomPerks()
    {
        return currrentPerks
            .OrderBy(x => Random.value)
            .Take(4)
            .ToList();
    }

    public void ApplyPerk(StatPerk perk)
    {
        switch (perk.perkType)
        {
            case PerkType.MaxHealth:
                statsMultiplier.healthMultiplier += perk.perkValue;
                break;
            
            case PerkType.Damage:
                statsMultiplier.damageMultiplier += perk.perkValue;
                break;

            case PerkType.HealthRegen:
                statsMultiplier.healthRegenMultiplier += perk.perkValue;
                break;
            
            case PerkType.Cooldown:
                statsMultiplier.cooldownMultiplier -= perk.perkValue;
                break;

            case PerkType.MoveSpeed:
                statsMultiplier.moveSpeedMultiplier += perk.perkValue;
                break;
            
            case PerkType.BonusExp:
                statsMultiplier.expMultiplier += perk.perkValue;
                break;

            case PerkType.ItemMagnet:
                statsMultiplier.itemMagnetMultiplier += perk.perkValue;
                break;
            
            case PerkType.Difficulty:
                statsMultiplier.difficultyMultiplier += perk.perkValue;
                break;

            case PerkType.Number:
                statsMultiplier.numberMultiplier += perk.perkValue;
                break;

            case PerkType.AxePerk:
                statsMultiplier.axeBonus += perk.perkValue;
                statsMultiplier.axeCooldownBonus -= 0.05f;
                statsMultiplier.axeNumberBonus += 1f;
                break;

            case PerkType.AuraPerk:
                statsMultiplier.auraBonus += perk.perkValue;
                statsMultiplier.auraCooldownBonus -= 0.05f;
                break;

            case PerkType.DaggerPerk:
                statsMultiplier.daggerBonus += perk.perkValue;
                statsMultiplier.daggerCooldownBonus -= 0.05f;
                statsMultiplier.daggerNumberBonus += 1f;
                break;

            case PerkType.RingPerk:
                statsMultiplier.ringBonus += perk.perkValue;
                statsMultiplier.ringCooldownBonus -= 0.05f;
                statsMultiplier.ringNumberBonus += 1f;
                break;

            case PerkType.StaffPerk:
                statsMultiplier.staffBonus += perk.perkValue;
                statsMultiplier.staffCooldownBonus -= 0.05f;
                statsMultiplier.staffNumberBonus += 1f;
                break;

            case PerkType.SwordPerk:
                statsMultiplier.swordBonus += perk.perkValue;
                statsMultiplier.swordCooldownBonus -= 0.05f;
                break;
        }
    }

    public void AddWeaponPerk(StatPerk newPerk)
    {
        if (!currrentPerks.Contains(newPerk))
        {
            currrentPerks.Add(newPerk);
        }
    }
}
