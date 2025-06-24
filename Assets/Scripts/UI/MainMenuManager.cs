using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Przycisk rozpocznij
    public void OnStartGamePress()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
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
