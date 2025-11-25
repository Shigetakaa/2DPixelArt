using UnityEngine;

public class AxeItem : MonoBehaviour
{
    public GameObject axe;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            axe.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
