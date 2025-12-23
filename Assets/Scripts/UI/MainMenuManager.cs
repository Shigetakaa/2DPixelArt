using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    public GameObject mainMenu;
    public GameObject startGameScreen;

    void Update()
    {
        coinsText.text = "Monety: " + CoinsManager.Instance.Coins.ToString();
    }

    // Przycisk rozpocznij
    public void OnStartPress()
    {
        mainMenu.SetActive(false);
        startGameScreen.SetActive(true);
    }

    // Przycisk ulepszenia
    public void OnUpgradesPress()
    {
        SceneManager.LoadScene("Upgrades");
    }

    // Przycisk instrukcja
    public void OnInstructionsPress()
    {
        SceneManager.LoadScene("Instructions");
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
