using System;
using TMPro;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    public string mapName;

    public TextMeshProUGUI easyScore;
    public TextMeshProUGUI normalScore;
    public TextMeshProUGUI hardScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadScores();
    }

    private void LoadScores()
    {
        int easy = GameSettingsManager.Instance.GetKilledEnemies(mapName, Difficulty.Easy);
        int normal = GameSettingsManager.Instance.GetKilledEnemies(mapName, Difficulty.Normal);
        int hard = GameSettingsManager.Instance.GetKilledEnemies(mapName, Difficulty.Hard);

        easyScore.text = easy.ToString();
        normalScore.text = normal.ToString();
        hardScore.text = hard.ToString();
    }
}
