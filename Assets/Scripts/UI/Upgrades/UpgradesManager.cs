using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    public static event System.Action OnUpgradeReset;

    public static UpgradesManager Instance;

    public List<Upgrades> upgrades;

    private PlayerStatsMultiplier statsMultiplier;
    private Health health;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // controller = FindAnyObjectByType<Controller>();
        // weaponParent = FindAnyObjectByType<WeaponParent>();
        // health = FindAnyObjectByType<Health>();

        // GetUpgrades();
    }

    public void SetUpgrades(Health newHealth)
    {
        health = newHealth;
        // controller = newHealth.GetComponent<Controller>();
        statsMultiplier = newHealth.GetComponent<PlayerStatsMultiplier>();

        GetUpgrades();
    }

    public void GetUpgrades()
    {
        foreach(var upgrade in upgrades)
        {
            int upgradeLevel = UpgradeSaveManager.GetUpgradeLevel(upgrade.upgradeName);

            if(upgradeLevel == 0)
            {
                continue;
            }

            float bonus = upgradeLevel * upgrade.statBonusPerLevel;

            GetBonus(upgrade.upgradeType, bonus);
        }
    }

    private void GetBonus(UpgradeType upgradeType, float bonus)
    {
        switch (upgradeType)
        {
            case UpgradeType.MoveSpeed:
                statsMultiplier?.AddMoveSpeedBonus(bonus);
                break;

            case UpgradeType.Damage:
                statsMultiplier?.AddDamageBonus(bonus);
                break;

            case UpgradeType.AttackCooldown:
                statsMultiplier?.AddAttackCooldownBonus(bonus);
                break;
            
            case UpgradeType.MaxHealth:
                health?.AddMaxHealthBonus(bonus);
                break;

            case UpgradeType.RegenHealth:
                health?.AddRegenHealthBonus(bonus);
                break;

            case UpgradeType.BonusExp:
                statsMultiplier?.AddExpBonus(bonus);
                break;

            case UpgradeType.ItemMagnet:
                statsMultiplier?.AddItemMagnetBonus(bonus);
                break;

            case UpgradeType.Difficulty:
                statsMultiplier?.AddDifficultyBonus(bonus);
                break;
        }
    }

    private int RefundCoin(Upgrades upgrades, int level)
    {
        int totalCoins = 0;

        for(int i = 0; i < level; i++)
        {
            totalCoins += upgrades.GetCostForLevel(i);
        }

        return totalCoins;
    }

    public void ResetUpgrades()
    {
        int refundCoins = 0;

        foreach (var upgrade in upgrades)
        {
            int upgradeLevel = UpgradeSaveManager.GetUpgradeLevel(upgrade.upgradeName);

            if(upgradeLevel > 0)
            {
                refundCoins += RefundCoin(upgrade, upgradeLevel);
                UpgradeSaveManager.SetUpgradeLevel(upgrade.upgradeName, 0);
            }
        }

        CoinsManager.Instance.GetCoins(refundCoins);
        
        OnUpgradeReset?.Invoke();
    }
}
