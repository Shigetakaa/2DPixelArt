using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI upgradeCoinsText;

    public GameObject mainMenu;
    public GameObject startGameScreen;
    public GameObject scoreboardScreen;
    public GameObject settingsScreen;
    public GameObject weaponsScreen;
    public GameObject upgradeScreen;

    public AudioClip buttonSound;
    private AudioSource audioSource;
    public AudioMixer audioMixer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        coinsText.text = CoinsManager.Instance.Coins.ToString();
        upgradeCoinsText.text = CoinsManager.Instance.Coins.ToString();
    }

    // Przycisk rozpocznij
    public void OnStartPress()
    {
        mainMenu.SetActive(false);
        startGameScreen.SetActive(true);

        PlayButtonSound();
    }

    public void OnWeaponsPress()
    {
        mainMenu.SetActive(false);
        weaponsScreen.SetActive(true);

        PlayButtonSound();
    }

    public void OnWeaponsBackPress()
    {
        mainMenu.SetActive(true);
        weaponsScreen.SetActive(false);

        PlayButtonSound();
    }

    // Przycisk ulepszenia
    public void OnUpgradesPress()
    {
        mainMenu.SetActive(false);
        upgradeScreen.SetActive(true);

        PlayButtonSound();
    }

    public void OnUpgradesBackPress()
    {
        mainMenu.SetActive(true);
        upgradeScreen.SetActive(false);

        PlayButtonSound();
    }

    // Przycisk wyniki
    public void OnScoreboardPress()
    {
        mainMenu.SetActive(false);
        scoreboardScreen.SetActive(true);

        PlayButtonSound();
    }

    public void OnScoreboardBackPress()
    {
        mainMenu.SetActive(true);
        scoreboardScreen.SetActive(false);

        PlayButtonSound();
    }

    // Przycisk ustawienia
    public void OnSettingsPress()
    {
        mainMenu.SetActive(false);
        settingsScreen.SetActive(true);

        PlayButtonSound();
    }

    public void OnSettingsBackPress()
    {
        mainMenu.SetActive(true);
        settingsScreen.SetActive(false);

        PlayButtonSound();
    }

    // Przycisk wyjdź
    public void OnCloseGamePress()
    {
        Application.Quit();
    }

    public void PlayButtonSound()
    {
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
