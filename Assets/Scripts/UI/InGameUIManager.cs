using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public GameObject healthBar;
    public GameObject characterParameters;
    public GameObject timerText;
    public TextMeshProUGUI killedEnemiesText;
    public TextMeshProUGUI coinsText;

    // Przycisk wróć do gry
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Przycisk menu główne
    public void OnMenuPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Przycisk wyjdź
    public void OnCloseGamePress()
    {
        Application.Quit();
    }

    // UI Końca gry
    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        // Wyłączenie paska zdrowia po śmierci gracza
        if (healthBar != null)
        {
            healthBar.SetActive(false);
        }
    }

    // UI Panelu wygranej
    public void VictoryScreen(int killedEnemies)
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
        killedEnemiesText.text = "Wrogowie: " + killedEnemies;
        coinsText.text = "Monety: " + CoinsManager.Instance.Coins.ToString();
        characterParameters.SetActive(false);
        timerText.SetActive(false);
    }
}
