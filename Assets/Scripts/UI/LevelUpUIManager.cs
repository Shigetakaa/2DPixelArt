using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIManager : MonoBehaviour
{
    public GameObject levelUpPanel;
    public GameObject characterStats;
    public GameObject characterParameters;

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

    public LevelUpPanelManager levelUpPanelManager;
    private List<StatPerk> currentPerks;

    // public void Initialize(LevelUpPanelManager manager)
    // {
    //     levelUpPanelManager = manager;
    // }

    public void ShowButtons(List<StatPerk> buttons)
    {
        Time.timeScale = 0;
        levelUpPanel.SetActive(true);

        currentPerks = buttons;

        button1Text.text = buttons[0].perkName;
        button2Text.text = buttons[1].perkName;
        button3Text.text = buttons[2].perkName;

        button1Description.text = buttons[0].perkDescription;
        button2Description.text = buttons[1].perkDescription;
        button3Description.text = buttons[2].perkDescription;

        button1Icon.sprite = buttons[0].perkIcon;
        button2Icon.sprite = buttons[1].perkIcon;
        button3Icon.sprite = buttons[2].perkIcon;

        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();

        button1.onClick.AddListener(() => ChoosePerk(0));
        button2.onClick.AddListener(() => ChoosePerk(1));
        button3.onClick.AddListener(() => ChoosePerk(2));
    }

    public void ChoosePerk(int i)
    {
        levelUpPanelManager.ApplyPerk(currentPerks[i]);

        Time.timeScale = 1;
        levelUpPanel.SetActive(false);
        characterParameters.SetActive(false);
        characterStats.SetActive(true);
    }
}
