using UnityEngine;

public class CoinItem : MonoBehaviour
{
    public int minCoinAmount = 1;
    public int maxCoinAmount = 5;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int randomCoinAmount = Random.Range(minCoinAmount, maxCoinAmount + 1);
            CoinsManager.Instance.GetCoins(randomCoinAmount);
            Destroy(gameObject);
        }
    }
}
