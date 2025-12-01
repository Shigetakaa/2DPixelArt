using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float healthAmoount = 5;

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
