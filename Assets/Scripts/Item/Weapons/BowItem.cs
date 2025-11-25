using UnityEngine;

public class BowItem : MonoBehaviour
{
    public GameObject bow;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bow.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
