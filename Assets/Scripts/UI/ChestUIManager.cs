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

    private SecondaryWeaponsManager secondaryWeapons;
    private List<GameObject> currentButtons;

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

    public void ShowButtons(List<GameObject> buttons)
    {
        Time.timeScale = 0;
        chestPanel.SetActive(true);
        currentButtons = buttons;

        button1Text.text = buttons[0].name;
        button2Text.text = buttons[1].name;
        button3Text.text = buttons[2].name;

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
