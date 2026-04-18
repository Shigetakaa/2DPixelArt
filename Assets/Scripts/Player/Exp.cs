using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    public float exp = 0f;
    public float maxExp = 10f;

    public int level = 1;

    public TextMeshProUGUI levelText;

    public Slider expBar;

    public GameObject levelUpScreen;

    public GameObject characterStats;
    public GameObject characterParameters;
    public GameObject equipmentPanel;

    public LevelUpPanelManager levelUpPanelManager;
    public LevelUpUIManager levelUpUIManager;

    public PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Wartość slidera doświadczenia = wartość doświadczenia gracza
        expBar.maxValue = maxExp;
        expBar.value = exp;

        // Wrtość poziomu postaci w UI
        levelText.text = "LVL: " + level.ToString();
    }

    // Metoda otrzymywania doświadczenia
    public void GetExp(float amount)
    {
        float finalAmount = amount * statsMultiplier.expMultiplier;

        exp += finalAmount;

        if (exp >= maxExp)
        {
            GetLevel();
        }
    }

    // Metoda otrzymywania poziomów postaci
    public void GetLevel()
    {
        level++;
        exp -= maxExp;
        maxExp *= 1.25f;

        var perks = levelUpPanelManager.GetRandomPerks();
        levelUpUIManager.ShowButtons(perks);

        characterStats.SetActive(false);
        characterParameters.SetActive(true);
        equipmentPanel.SetActive(true);

        Time.timeScale = 0;
    }
}
