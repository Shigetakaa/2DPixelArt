using UnityEngine;
using UnityEngine.Audio;

public class ResetUpgradesButton : MonoBehaviour
{
    public AudioClip resetSound;
    private AudioSource audioSource;
    public AudioMixer audioMixer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnResetUpgradesButton()
    {
        UpgradesManager.Instance.ResetUpgrades();

        audioSource.clip = resetSound;
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
