using UnityEngine;

public class AuraItem : MonoBehaviour
{
    public GameObject aura;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            aura.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
