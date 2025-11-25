using UnityEngine;

public class StaffItem : MonoBehaviour
{
    public GameObject staff;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            staff.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
