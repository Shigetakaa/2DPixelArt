using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public float expAmount = 4f;

    // Exp jest dodawany po interakcji z graczem
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
