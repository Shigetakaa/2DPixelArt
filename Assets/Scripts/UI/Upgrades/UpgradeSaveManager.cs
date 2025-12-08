using UnityEngine;

public static class UpgradeSaveManager
{
    private static string Key(string upgradeName)
    {
        return "UPGRADE_" + upgradeName;
    }

    public static int GetUpgradeLevel(string upgradeName)
    {
        return PlayerPrefs.GetInt(Key(upgradeName), 0);
    }

    public static void SetUpgradeLevel(string upgradeName, int level)
    {
        PlayerPrefs.SetInt(Key(upgradeName), level);
        PlayerPrefs.Save();
    }

    public static void IncreaseUpgradeLevel(string upgradeName)
    {
        int upgradeLevel = GetUpgradeLevel(upgradeName);
        upgradeLevel++;
        SetUpgradeLevel(upgradeName, upgradeLevel);
    }

    public static void ResetUpgrade(string upgradeName)
    {
        PlayerPrefs.DeleteKey(Key(upgradeName));
    }
}
