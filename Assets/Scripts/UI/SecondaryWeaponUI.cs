using System;
using TMPro;
using UnityEngine;

public class SecondaryWeaponUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI cooldownText;

    public TextMeshProUGUI numberTextArea;

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
        cooldownText.text = secondaryWeapon.GetCooldown().ToString("F2") + "s";

        if(secondaryWeapon is Aura)
        {
            numberText.gameObject.SetActive(false);
            numberTextArea.gameObject.SetActive(false);
        }
        else
        {
            numberText.gameObject.SetActive(true);
            numberTextArea.gameObject.SetActive(true);
            numberText.text = secondaryWeapon.GetNumber().ToString("F0");
        }
    }
}
