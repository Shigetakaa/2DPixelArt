using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager Instance;

    public List<Upgrades> upgrades;

    private Controller controller;
    private WeaponParent weaponParent;
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
        controller = FindAnyObjectByType<Controller>();
        weaponParent = FindAnyObjectByType<WeaponParent>();
        health = FindAnyObjectByType<Health>();

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
                controller?.AddMoveSpeedBonus(bonus);
                break;

            case UpgradeType.Damage:
                weaponParent?.AddDamageBonus(bonus);
                break;

            case UpgradeType.AttackCooldown:
                weaponParent?.AddAttackCooldownBonus(bonus);
                break;
            
            case UpgradeType.MaxHealth:
                health?.AddMaxHealthBonus(bonus);
                break;

            case UpgradeType.RegenHealth:
                health?.AddRegenHealthBonus(bonus);
                break;
        }
    }

    public void ResetUpgrades()
    {
        foreach (var upgrade in upgrades)
        {
            UpgradeSaveManager.SetUpgradeLevel(upgrade.upgradeName, 0);
        }
    }
}
