using UnityEngine;

public class Aura : MonoBehaviour
{
    public float auraDamage = 3f;
    public float auraRadius = 5f;
    public float auraCooldown = 2f;
    public float lastAttack;

    private CircleCollider2D auraCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        auraCollider = GetComponent<CircleCollider2D>();
        auraCollider.isTrigger = true;
        auraCollider.radius = auraRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        DealDamage(collision);
    }

    // Metoda zadająca obrażenia
    public void DealDamage(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            if(Time.time >= lastAttack + auraCooldown)
            {
                lastAttack = Time.time;

                BossHealth bossHealth = collision.GetComponent<BossHealth>();
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
                if (bossHealth != null)
                {
                    bossHealth.GetHit(auraDamage, this.gameObject);
                }
                else if (enemyHealth != null)
                {
                    enemyHealth.GetHit(auraDamage, this.gameObject);
                }
            }
        }
    }
}
