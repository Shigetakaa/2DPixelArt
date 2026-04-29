using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    public Slider volumeSlider;

    void Start()
    {
        GetResolutions();
        GetSettings();
    }

    void SavedResolutionIndex()
    {
        if (PlayerPrefs.HasKey("resolutionIndex"))
        {
            int savedIndex = PlayerPrefs.GetInt("resolutionIndex");

            resolutionDropdown.value = savedIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    void GetResolutions()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        var options = new List<string>();
        var unique = new HashSet<string>();
        var uniqueResolutions = new List<Resolution>();

        foreach(var res in resolutions)
        {
            string key = res.width + "x" + res.height;

            if (unique.Add(key))
            {
                options.Add(res.width + " x " + res.height);
                uniqueResolutions.Add(res);
            }
        }

        resolutions = uniqueResolutions.ToArray();
        resolutionDropdown.AddOptions(options);
    }

    public void SetVolume(float volume)
    {
        float db = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;

        audioMixer.SetFloat("volume", db);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("fullscreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];

        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

        PlayerPrefs.SetInt("resolutionIndex", index);
        PlayerPrefs.Save();
    }

    public void GetSettings()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            float vol = PlayerPrefs.GetFloat("volume");
            volumeSlider.value = vol;

            float db = Mathf.Log10(Mathf.Clamp(vol, 0.0001f, 1f)) * 20f;
            audioMixer.SetFloat("volume", db);
        }


        int index = PlayerPrefs.GetInt("resolutionIndex", 0);
        index = Mathf.Clamp(index, 0, resolutions.Length - 1);
        resolutionDropdown.value = index;
        resolutionDropdown.RefreshShownValue();
        SetResolution(index);


        bool isFullScreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        fullScreenToggle.isOn = isFullScreen;
        Screen.fullScreen = isFullScreen;

    }
}
