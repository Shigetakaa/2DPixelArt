using UnityEngine;

public class PotionItem : MonoBehaviour
{
    public float healthAmoount = 15;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health player = collision.GetComponent<Health>();

        if (player != null)
        {
            player.GetHealth(healthAmoount);
            Destroy(gameObject);
        }
    }
}
