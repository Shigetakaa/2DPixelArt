using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    public GameObject mainMenu;
    public GameObject startGameScreen;
    public GameObject scoreboardScreen;
    public GameObject controls;
    public GameObject settingsScreen;
    public GameObject weaponsScreen;

    void Update()
    {
        coinsText.text = CoinsManager.Instance.Coins.ToString();
    }

    // Przycisk rozpocznij
    public void OnStartPress()
    {
        mainMenu.SetActive(false);
        controls.SetActive(false);
        startGameScreen.SetActive(true);
    }

    // Przycisk ulepszenia
    public void OnUpgradesPress()
    {
        SceneManager.LoadScene("Upgrades");
    }

    // Przycisk wyniki
    public void OnScoreboardPress()
    {
        mainMenu.SetActive(false);
        controls.SetActive(false);
        scoreboardScreen.SetActive(true);
    }

    public void OnScoreboardBackPress()
    {
        mainMenu.SetActive(true);
        controls.SetActive(true);
        scoreboardScreen.SetActive(false);
    }

    // Przycisk ustawienia
    public void OnSettingsPress()
    {
        SceneManager.LoadScene("Settings");
    }

    // Przycisk wyjdź
    public void OnCloseGamePress()
    {
        Application.Quit();
    }

    // Przycisk wróć do menu głównego
    public void OnBackPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
