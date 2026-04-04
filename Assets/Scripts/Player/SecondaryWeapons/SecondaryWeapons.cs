using UnityEngine;

[CreateAssetMenu(fileName = "SecondaryWeapons", menuName = "Scriptable Objects/SecondaryWeapons")]
public class SecondaryWeapons : ScriptableObject
{
    public string weaponName;
    public Sprite weaponIcon;
    public string weaponDescription;

    public GameObject secondaryWeapon;

    public StatPerk weaponPerk;
}
