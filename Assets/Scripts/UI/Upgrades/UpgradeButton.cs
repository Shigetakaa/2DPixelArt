using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public Upgrades upgrades;
    public TextMeshProUGUI buttonNameText;
    public TextMeshProUGUI buttonDescriptionText;
    public Image buttonIcon;
    public TextMeshProUGUI buttonLevelText;
    public TextMeshProUGUI buttonCostText;
    public Button button;

    private int upgradeLevel;
    private int upgradeCost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshUI();

        UpgradesManager.OnUpgradeReset += RefreshUI;
        CoinsManager.OnCoinsChanged += RefreshUI;
    }

    void OnDestroy()
    {
        UpgradesManager.OnUpgradeReset -= RefreshUI;
        CoinsManager.OnCoinsChanged -= RefreshUI;
    }

    public void RefreshUI()
    {
        upgradeLevel = UpgradeSaveManager.GetUpgradeLevel(upgrades.upgradeName);
        upgradeCost = upgrades.GetCostForLevel(upgradeLevel);

        buttonNameText.text = upgrades.upgradeName;
        buttonLevelText.text = "Poziom: " + upgradeLevel;
        buttonCostText.text = "Koszt: " + upgradeCost;
        buttonIcon.sprite = upgrades.upgradeIcon;
        buttonDescriptionText.text = upgrades.upgradeDescription;

        button.interactable = (CoinsManager.Instance.Coins >= upgradeCost);
    }

    public void OnBuyUpgradePress()
    {
        if(CoinsManager.Instance.Coins < upgradeCost)
        {
            return;
        }
        else if(upgradeLevel >= upgrades.maxLevel)
        {
            return;
        }

        CoinsManager.Instance.GetCoins(-upgradeCost);
        UpgradeSaveManager.IncreaseUpgradeLevel(upgrades.upgradeName);
        UpgradesManager.Instance.GetUpgrades();

        RefreshUI();
    }
}
