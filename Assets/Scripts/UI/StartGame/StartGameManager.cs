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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChosenMap(string map)
    {
        Button pressedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if(pressedMapButton != null)
        {
            pressedMapButton.OnDeselect(null);
        }
        pressedMapButton = pressedButton;
        pressedMapButton.Select();

        GameSettingsManager.Instance.chosenMap = map;
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
        SceneManager.LoadScene(GameSettingsManager.Instance.chosenMap);
    }

    public void OnBackPress()
    {
        mainMenu.SetActive(true);
        startGameScreen.SetActive(false);
    }
}
