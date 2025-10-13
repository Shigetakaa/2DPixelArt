using UnityEngine;

public class Exp : MonoBehaviour
{
    public float exp = 0f;
    public float maxExp = 10f;

    public int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

        if (exp == maxExp)
        {
            GetLevel();
        }
    }

    // Metoda otrzymywania poziomów postaci
    public void GetLevel()
    {
        exp = 0f;
        maxExp += 4f;
        level += 1;
    }
}
