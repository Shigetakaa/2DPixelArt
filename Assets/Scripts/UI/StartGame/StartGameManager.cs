using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    public Button startGameButton;

    private Button pressedMapButton;
    private Button pressedDifficultyButton;

    public GameObject mainMenu;
    public GameObject startGameScreen;
    public GameObject controls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChosenMap(int mapIndex)
    {
        Button pressedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if(pressedMapButton != null)
        {
            pressedMapButton.OnDeselect(null);
        }
        pressedMapButton = pressedButton;
        pressedMapButton.Select();

        GameSettingsManager.Instance.chosenMap = (Map)mapIndex;
        UpdateStartButton();
    }

    private void UpdateStartButton()
    {
        startGameButton.interactable = pressedMapButton != null && pressedDifficultyButton != null;
    }

    public void ChosenDifficulty(int difficultyIndex)
    {
        Button pressedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if(pressedDifficultyButton != null)
        {
            pressedDifficultyButton.OnDeselect(null);
        }
        pressedDifficultyButton = pressedButton;
        pressedDifficultyButton.Select();

        GameSettingsManager.Instance.chosenDifficulty = (Difficulty)difficultyIndex;
        UpdateStartButton();
    }

    public void OnStartGamePress()
    {
        SceneManager.LoadScene(GameSettingsManager.Instance.chosenMap.ToString());
        Time.timeScale = 1;
    }

    public void OnBackPress()
    {
        mainMenu.SetActive(true);
        controls.SetActive(true);
        startGameScreen.SetActive(false);
    }
}
