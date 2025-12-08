using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeaponsManager : MonoBehaviour
{
    public List<GameObject> secondaryWeapons;
    public List<GameObject> currentSecondaryWeapons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSecondaryWeapons = new List<GameObject>(secondaryWeapons);

        foreach (var weapon in currentSecondaryWeapons)
        {
            weapon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWeapon(GameObject chosenWeapon)
    {
        chosenWeapon.SetActive(true);
        currentSecondaryWeapons.Remove(chosenWeapon);
    }
}
