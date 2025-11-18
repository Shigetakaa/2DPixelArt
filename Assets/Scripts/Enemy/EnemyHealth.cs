using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 10f;
    public float maxEnemyHealth = 10f;

    public int killedEnemies = 0;

    private bool isDead = false;

    public GameObject expItem;

    public UnityEvent<GameObject> OnHit, OnDeath;

    public TextMeshProUGUI killedEnemiesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Inicjujemy zdrowie obiektu
    public void InitializeHealth(float healthValue)
    {
        enemyHealth = healthValue;
        maxEnemyHealth = healthValue;
        isDead = false;
    }

    // Metoda otrzymywania obrażeń
    public void GetHit(float damage, GameObject sender)
    {
        if(isDead)
            return;
        if(sender.layer == gameObject.layer)
            return;

        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            OnDeath?.Invoke(sender);
            isDead = true;

            // Pojawia się doświadczenie po śmieci wroga
            Instantiate(expItem, transform.position, Quaternion.identity);

            Destroy(gameObject);

            // Ilość pokonanych wrogów
            Health player = sender.GetComponent<Health>();
            if (player != null && player.isPlayer)
            {
                player.killedEnemies++;
                if (player.killedEnemiesText != null)
                {
                    player.killedEnemiesText.text = "Pokonani wrogowie: " + player.killedEnemies;
                }
            }
        }
        else
        {
            OnHit?.Invoke(sender);
        }
    }
}
