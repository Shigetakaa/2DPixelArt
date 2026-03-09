using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeaponsManager : MonoBehaviour
{
    public List<SecondaryWeapons> secondaryWeapons;
    public List<SecondaryWeapons> currentSecondaryWeapons;

    public Transform secondaryWeaponsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSecondaryWeapons = new List<SecondaryWeapons>(secondaryWeapons);

        // foreach (var weapon in currentSecondaryWeapons)
        // {
        //     weapon.secondaryWeapon.SetActive(false);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWeapon(SecondaryWeapons chosenWeapon)
    {
        Instantiate(chosenWeapon.secondaryWeapon, secondaryWeaponsManager);
        currentSecondaryWeapons.Remove(chosenWeapon);
    }
}
