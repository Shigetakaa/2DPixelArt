using UnityEngine;

public class AuraItem : MonoBehaviour
{
    public GameObject aura;
    public GameObject player;

    // Aura jest używana po interakcji z graczem
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(player != null)
        {
            aura.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
