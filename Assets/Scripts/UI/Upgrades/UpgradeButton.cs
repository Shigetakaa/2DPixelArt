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
    public TextMeshProUGUI buttonLevelText;
    public TextMeshProUGUI buttonCostText;
    public Button button;

    private int upgradeLevel;
    private int upgradeCost;

    public GameObject noCoinsWindow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshUI();

        button.onClick.AddListener(OnBuyUpgradePress);
    }

    private void RefreshUI()
    {
        upgradeLevel = UpgradeSaveManager.GetUpgradeLevel(upgrades.upgradeName);
        upgradeCost = upgrades.GetCostForLevel(upgradeLevel);

        buttonNameText.text = upgrades.upgradeName;
        buttonLevelText.text = "Level: " + upgradeLevel;
        buttonCostText.text = upgradeCost + " monet";

        button.interactable = (CoinsManager.Instance.Coins >= upgradeCost);
    }

    private void OnBuyUpgradePress()
    {
        if(CoinsManager.Instance.Coins < upgradeCost)
        {
            noCoinsWindow.SetActive(true);
            return;
        }

        CoinsManager.Instance.GetCoins(-upgradeCost);
        UpgradeSaveManager.IncreaseUpgradeLevel(upgrades.upgradeName);
        UpgradesManager.Instance.GetUpgrades();

        RefreshUI();
    }
}
