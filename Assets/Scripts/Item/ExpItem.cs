using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public float expAmount = 4f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Exp player = collision.gameObject.GetComponent<Exp>();

        if (player != null)
        {
            player.GetExp(expAmount);
            Destroy(gameObject);
        }
    }
}
