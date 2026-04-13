using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeaponsManager : MonoBehaviour
{
    public List<SecondaryWeapons> secondaryWeapons;
    public List<SecondaryWeapons> currentSecondaryWeapons;
    public List<SecondaryWeapons> ownedSecondaryWeapons;
    public List<SecondaryWeaponStats> activeWeaponsIcons = new List<SecondaryWeaponStats>();

    public Transform secondaryWeaponsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSecondaryWeapons = new List<SecondaryWeapons>(secondaryWeapons);
        ownedSecondaryWeapons = new List<SecondaryWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject ActivateWeapon(SecondaryWeapons chosenWeapon)
    {
        GameObject obj = Instantiate(chosenWeapon.secondaryWeapon, secondaryWeaponsManager);

        currentSecondaryWeapons.Remove(chosenWeapon);
        ownedSecondaryWeapons.Add(chosenWeapon);

        SecondaryWeaponStats weaponStats = obj.GetComponent<SecondaryWeaponStats>();
        if(weaponStats != null)
        {
            activeWeaponsIcons.Add(weaponStats);
        }

        return obj;
    }
}
