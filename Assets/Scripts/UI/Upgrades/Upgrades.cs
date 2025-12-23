using UnityEngine;

public enum UpgradeType
{
    MoveSpeed,
    AttackCooldown,
    MaxHealth,
    RegenHealth,
    Damage
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Scriptable Objects/Upgrades")]
public class Upgrades : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeIcon;

    public int cost = 500;
    public float costMultiplier = 2f;

    public int maxLevel = 5;

    public float statBonusPerLevel = 1f;

    public UpgradeType upgradeType;

    public int GetCostForLevel(int level)
    {
        float costForLevel = cost * Mathf.Pow(costMultiplier, level);
        return Mathf.RoundToInt(costForLevel);
    }
}
