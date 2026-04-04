using System.Collections;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public float auraDamage = 10f;
    public float finalDamage;
    public float auraRadius = 5f;
    public float auraCooldown = 2f;

    private CircleCollider2D auraCollider;

    public GameObject player;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        auraCollider = GetComponent<CircleCollider2D>();
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

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
        float finalCooldown = auraCooldown * statsMultiplier.cooldownMultiplier;

        while (true)
        {
            yield return new WaitForSeconds(finalCooldown);
            DealDamage();
        }
    }

    // Metoda zadająca obrażenia
    public void DealDamage()
    {
        finalDamage = (auraDamage + statsMultiplier.auraBonus) * statsMultiplier.damageMultiplier;

        foreach (Collider2D collision in Physics2D.OverlapCircleAll(transform.position, auraRadius))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (bossHealth != null)
            {
                bossHealth.GetHit(finalDamage, player);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(finalDamage, player);
            }
        }
    }
}
