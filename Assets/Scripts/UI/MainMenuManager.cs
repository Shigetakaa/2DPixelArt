using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI upgradeCoinsText;

    public GameObject mainMenu;
    public GameObject startGameScreen;
    public GameObject scoreboardScreen;
    public GameObject settingsScreen;
    public GameObject weaponsScreen;
    public GameObject upgradeScreen;

    void Update()
    {
        coinsText.text = CoinsManager.Instance.Coins.ToString();
        upgradeCoinsText.text = CoinsManager.Instance.Coins.ToString();
    }

    // Przycisk rozpocznij
    public void OnStartPress()
    {
        mainMenu.SetActive(false);
        startGameScreen.SetActive(true);
    }

    public void OnWeaponsPress()
    {
        mainMenu.SetActive(false);
        weaponsScreen.SetActive(true);
    }

    public void OnWeaponsBackPress()
    {
        mainMenu.SetActive(true);
        weaponsScreen.SetActive(false);
    }

    // Przycisk ulepszenia
    public void OnUpgradesPress()
    {
        mainMenu.SetActive(false);
        upgradeScreen.SetActive(true);
    }

    public void OnUpgradesBackPress()
    {
        mainMenu.SetActive(true);
        upgradeScreen.SetActive(false);
    }

    // Przycisk wyniki
    public void OnScoreboardPress()
    {
        mainMenu.SetActive(false);
        scoreboardScreen.SetActive(true);
    }

    public void OnScoreboardBackPress()
    {
        mainMenu.SetActive(true);
        scoreboardScreen.SetActive(false);
    }

    // Przycisk ustawienia
    public void OnSettingsPress()
    {
        mainMenu.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void OnSettingsBackPress()
    {
        mainMenu.SetActive(true);
        settingsScreen.SetActive(false);
    }

    // Przycisk wyjdź
    public void OnCloseGamePress()
    {
        Application.Quit();
    }
}
