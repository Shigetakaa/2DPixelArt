using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundObject;
    public AudioMixer audioMixer;

    private Dictionary<AudioClip, float> lastPlayTimes = new Dictionary<AudioClip, float>();
    public float soundCooldown = 0.1f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySound(AudioClip audio, Transform spawnTranform, float volume)
    {
        if (lastPlayTimes.ContainsKey(audio))
        {
            if(Time.time - lastPlayTimes[audio] < soundCooldown)
            {
                return;
            }
        }
        lastPlayTimes[audio] = Time.time;

        AudioSource audioSource = Instantiate(soundObject, spawnTranform.position, Quaternion.identity);

        audioSource.clip = audio;

        audioSource.volume = volume * GetVolume();

        audioSource.Play();

        float audioLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void PlayRandomSounds(AudioClip[] audio, Transform spawnTranform, float volume)
    {
        AudioClip clip = audio[Random.Range(0, audio.Length)];

        if (lastPlayTimes.ContainsKey(clip))
        {
            if(Time.time - lastPlayTimes[clip] < soundCooldown)
            {
                return;
            }
        }
        lastPlayTimes[clip] = Time.time;

        AudioSource audioSource = Instantiate(soundObject, spawnTranform.position, Quaternion.identity);

        audioSource.clip = clip;

        audioSource.volume = volume * GetVolume();

        audioSource.Play();

        float audioLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, audioSource.clip.length);
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
