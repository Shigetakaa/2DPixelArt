using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public GameObject pauseMenu;

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
}
