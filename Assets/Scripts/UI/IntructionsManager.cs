using UnityEngine;
using UnityEngine.SceneManagement;

public class IntructionsManager : MonoBehaviour
{
    // Przycisk zasady
    public void OnRulesPress()
    {
        SceneManager.LoadScene("Rules");
    }

    // Przycisk ulepszenia
    public void OnUpgradesInstructionsPress()
    {
        SceneManager.LoadScene("UpgradesInstructions");
    }

    // Przycisk interfejs
    public void OnInterfacePress()
    {
        SceneManager.LoadScene("Interface");
    }

    // Przycisk sterowanie
    public void OnControlsPress()
    {
        SceneManager.LoadScene("Controls");
    }

    // Przycisk wróć do menu głównego
    public void OnBackPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Przycisk wróć do menu intrukcji
    public void OnBackToInstructionsPress()
    {
        SceneManager.LoadScene("Instructions");
    }
}
