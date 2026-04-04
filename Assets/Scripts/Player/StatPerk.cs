using UnityEngine;

[CreateAssetMenu(fileName = "StatPerk", menuName = "Scriptable Objects/StatPerk")]
public class StatPerk : ScriptableObject
{
    public string perkName;
    public string perkDescription;
    public Sprite perkIcon;

    public PerkType perkType;
    public float perkValue;
}

public enum PerkType
{
    MaxHealth,
    Damage,
    HealthRegen,
    Cooldown,
    MoveSpeed,
    BonusExp,
    ItemMagnet,
    Difficulty,
    AxePerk,
    AuraPerk,
    StaffPerk,
    DaggerPerk,
    RingPerk,
    SwordPerk
}