using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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

    public AudioClip buttonSound;
    public AudioClip startGameSound;
    private AudioSource audioSource;
    public AudioMixer audioMixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.interactable = false;

        audioSource = GetComponent<AudioSource>();
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
        audioSource.clip = startGameSound;
        audioSource.volume = GetVolume();
        audioSource.Play();

        SceneManager.LoadScene(GameSettingsManager.Instance.chosenMap.ToString());
        Time.timeScale = 1;
    }

    public void OnBackPress()
    {
        mainMenu.SetActive(true);
        controls.SetActive(true);
        startGameScreen.SetActive(false);

        audioSource.clip = buttonSound;
        audioSource.volume = GetVolume();
        audioSource.Play();
    }

    public float GetVolume()
    {
        float db;
        if(audioMixer.GetFloat("volume", out db))
        {
            return Mathf.Pow(10f, db / 20f);
        }

        return 1f;
    }
}
