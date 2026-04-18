using System.Collections;
using UnityEngine;

public class Aura : MonoBehaviour, SecondaryWeaponStats
{
    public float auraDamage = 10f;
    public float finalDamage;
    public float auraRadius = 5f;
    public float auraCooldown = 2f;
    float finalCooldown;

    private CircleCollider2D auraCollider;

    public GameObject player;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        while (true)
        {
            yield return new WaitForSeconds(finalCooldown);
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
                bossHealth.GetHit(finalDamage, player);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(finalDamage, player);
            }
        }
    }

    public float GetDamage()
    {
        return finalDamage = (auraDamage + statsMultiplier.auraBonus) * statsMultiplier.damageMultiplier;
    }

    public float GetCooldown()
    {
        return finalCooldown = (auraCooldown + statsMultiplier.auraCooldownBonus) * statsMultiplier.cooldownMultiplier;
    }

    public float GetNumber()
    {
        return 1f;
    }
}
