using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestUIManager : MonoBehaviour
{
    public GameObject chestPanel;
    public Button button1;
    public Button button2;
    public Button button3;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    public TextMeshProUGUI button3Text;
    public TextMeshProUGUI button1Description;
    public TextMeshProUGUI button2Description;
    public TextMeshProUGUI button3Description;
    public Image button1Icon;
    public Image button2Icon;
    public Image button3Icon;

    private SecondaryWeaponsManager secondaryWeapons;
    private List<SecondaryWeapons> currentButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(SecondaryWeaponsManager secondaryWeaponsManager)
    {
        secondaryWeapons = secondaryWeaponsManager;
    }

    public void ShowButtons(List<SecondaryWeapons> buttons)
    {
        Time.timeScale = 0;
        chestPanel.SetActive(true);
        currentButtons = buttons;

        button1Text.text = buttons[0].weaponName;
        button2Text.text = buttons[1].weaponName;
        button3Text.text = buttons[2].weaponName;

        button1Description.text = buttons[0].weaponDescription;
        button2Description.text = buttons[1].weaponDescription;
        button3Description.text = buttons[2].weaponDescription;

        button1Icon.sprite = buttons[0].weaponIcon;
        button2Icon.sprite = buttons[1].weaponIcon;
        button3Icon.sprite = buttons[2].weaponIcon;

        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();

        button1.onClick.AddListener(() => ChooseButtons(0));
        button2.onClick.AddListener(() => ChooseButtons(1));
        button3.onClick.AddListener(() => ChooseButtons(2));
    }

    private void ChooseButtons(int i)
    {
        var weapon = currentButtons[i];
        secondaryWeapons.ActivateWeapon(weapon);

        Time.timeScale = 1;
        chestPanel.SetActive(false);
    }
}
