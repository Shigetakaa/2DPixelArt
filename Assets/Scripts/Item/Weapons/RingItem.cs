using UnityEngine;

public class RingItem : MonoBehaviour
{
    public GameObject ring;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ring.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
