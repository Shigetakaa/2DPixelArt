using System.Collections;
using UnityEngine;

public class Aura : MonoBehaviour, SecondaryWeaponStats
{
    public float auraDamage = 5f;
    public float finalDamage;
    public float auraRadius = 4.5f;
    public float auraCooldown = 4f;
    public float minCooldown = 0.1f;
    public float finalCooldown;

    public GameObject auraAttack;
    public GameObject player;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        StartCoroutine(ActivateAura());
    }

    // Update is called once per frame
    void Update()
    {
        finalCooldown = (auraCooldown + statsMultiplier.auraCooldownBonus) * statsMultiplier.cooldownMultiplier;
        finalCooldown = Mathf.Max(minCooldown, finalCooldown);
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
        Instantiate(auraAttack, transform.position, Quaternion.identity);

        finalDamage = GetDamage();

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
        return finalCooldown;
    }

    public float GetNumber()
    {
        return 1f;
    }
}
