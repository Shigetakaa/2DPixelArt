using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    public float exp = 0f;
    public float maxExp = 10f;

    public int level = 1;

    public TextMeshProUGUI levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Wartość slidera doświadczenia = wartość doświadczenia gracza
        GameObject.Find("ExpBar").GetComponent<Slider>().value = exp;

        // Wrtość poziomu postaci w UI
        levelText.text = "Poziom: " + level.ToString();
    }

    // Inicjujemy doświadczenie Gracza
    public void InitializeExp(float expValue)
    {
        exp = expValue;
        maxExp = expValue;
    }

    // Metoda otrzymywania doświadczenia
    public void GetExp(float amount)
    {
        exp += amount;

        if (exp >= maxExp)
        {
            GetLevel();
        }
    }

    // Metoda otrzymywania poziomów postaci
    public void GetLevel()
    {
        level++;
        exp -= maxExp;
        maxExp += 4f;
    }
}
