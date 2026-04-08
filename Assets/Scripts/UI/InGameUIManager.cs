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
    public GameObject characterStats;
    public GameObject timerText;
    public Health player;

    public TextMeshProUGUI killedEnemiesText;
    public TextMeshProUGUI victoryCoinsText;
    public TextMeshProUGUI gameOverCoinsText;
    public TextMeshProUGUI coinsText;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        coinsText.text = "Monety: " + player.coins;
    }

    // Przycisk wróć do gry
    public void OnResumePress()
    {
        characterParameters.SetActive(true);
        characterStats.SetActive(false);
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

        gameOverCoinsText.text = "Zdobyte monety: " + player.coins;
        
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
        victoryCoinsText.text = "Zdobyte monety: " + player.coins;

        characterParameters.SetActive(false);
        timerText.SetActive(false);
    }
}
