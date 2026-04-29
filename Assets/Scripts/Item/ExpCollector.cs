using JetBrains.Annotations;
using UnityEngine;

public class ExpCollector : MonoBehaviour
{
    public AudioClip itemSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(itemSound, transform, 1f);
            CollectExp(collision.transform);
            Destroy(gameObject);
        } 
    }

    public void CollectExp(Transform player)
    {
        ExpItem [] allExp = FindObjectsOfType<ExpItem>();

        foreach (ExpItem exp in allExp)
        {
            exp.MoveTo(player);
        }
    }
}
