using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float bossHealth = 100f;
    public float maxBossHealth = 100f;

    private bool isBoss = true;

    private bool isDead = false;

    private InGameUIManager victoryScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Wczytanie UI panelu wygranej
        victoryScreen = FindAnyObjectByType<InGameUIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Inicjujemy zdrowie bossa
    public void InitializeBossHealth(float bossHealthValue)
    {
        bossHealth = bossHealthValue;
        maxBossHealth = bossHealthValue;
        isDead = false;
    }
    
    // Metoda otrzymywania obrażeń
    public void GetHit(float damage, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;

        bossHealth -= damage;
        
        if(bossHealth <= 0)
        {
            // Panel wygranej po śmierci bossa
            victoryScreen.VictoryScreen();
            Destroy(gameObject);
        }
    }
}
