using JetBrains.Annotations;
using UnityEngine;

public class ExpCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
