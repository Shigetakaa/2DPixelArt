using UnityEngine;

public class PotionItem : MonoBehaviour
{
    public float healthAmoount = 15;

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
