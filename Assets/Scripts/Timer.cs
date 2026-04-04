using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainingTime;
    public float maxTime = 60.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Odliczanie czasu w dół
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }

        // Rozdzielenie czasu na minuty i sekundy
        int min = Mathf.FloorToInt(remainingTime / 60);
        int sec = Mathf.FloorToInt(remainingTime % 60);

        // Ustawienie formatu tekstu
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public float GetElapsedTime()
    {
        return maxTime - remainingTime;
    }
}
