using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float healthAmoount = 5;

    public AudioClip itemSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health player = collision.GetComponent<Health>();

        if (player != null)
        {
            SoundManager.instance.PlaySound(itemSound, transform, 1f);
            player.GetHealth(healthAmoount);
            Destroy(gameObject);
        }
    }
}
