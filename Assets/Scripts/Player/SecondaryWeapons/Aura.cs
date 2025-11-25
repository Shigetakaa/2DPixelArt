using System.Collections;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public float auraDamage = 3f;
    public float auraRadius = 5f;
    public float auraCooldown = 2f;

    private CircleCollider2D auraCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        auraCollider = GetComponent<CircleCollider2D>();
        auraCollider.isTrigger = true;
        auraCollider.radius = auraRadius;

        StartCoroutine(ActivateAura());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ActivateAura()
    {
        while (true)
        {
            yield return new WaitForSeconds(auraCooldown);
            DealDamage();
        }
    }

    // Metoda zadająca obrażenia
    public void DealDamage()
    {
        foreach (Collider2D collision in Physics2D.OverlapCircleAll(transform.position, auraRadius))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (bossHealth != null)
            {
                bossHealth.GetHit(auraDamage, transform.parent.gameObject);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(auraDamage, transform.parent.gameObject);
            }
        }
    }
}
