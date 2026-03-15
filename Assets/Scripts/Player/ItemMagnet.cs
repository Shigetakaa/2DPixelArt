using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
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
