using UnityEngine;

public class CoinItem : MonoBehaviour
{
    public int minCoinAmount = 1;
    public int maxCoinAmount = 5;

    private Health player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int randomCoinAmount = Random.Range(minCoinAmount, maxCoinAmount + 1);
            player.GetInGameCoins(randomCoinAmount);
            Destroy(gameObject);
        }
    }
}
