using System;
using TMPro;
using UnityEngine;

public class SecondaryWeaponUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI cooldownText;

    private SecondaryWeaponStats secondaryWeapon;

    public void Initialize(SecondaryWeaponStats weapon, string weaponName)
    {
        this.secondaryWeapon = weapon;
        nameText.text = weaponName;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(secondaryWeapon != null)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        damageText.text = secondaryWeapon.GetDamage().ToString("F2");
        numberText.text = secondaryWeapon.GetNumber().ToString("F0");
        cooldownText.text = secondaryWeapon.GetCooldown().ToString("F2") + "s";
    }
}
