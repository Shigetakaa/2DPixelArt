using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    public float itemMagnetRadius = 3.0f;
    public CircleCollider2D itemMagnet;

    public PlayerStatsMultiplier statsMultiplier;

    void Start()
    {
        float finalItemMagnerRadius = itemMagnetRadius * statsMultiplier.itemMagnetMultiplier;

        itemMagnet.radius = finalItemMagnerRadius;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickupItem"))
        {
            PickupItem item = collision.GetComponent<PickupItem>();

            if(item != null)
            {
                item.StartMagnet(transform);
            }
        }
    }
}
