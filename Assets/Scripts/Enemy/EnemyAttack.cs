using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyAttack;
    public float enemyDamage = 5f;
    public float enemyRadius = 0.7f;
    public float enemyAttackCooldown = 0.5f;
    public float lastAttack;

    private CircleCollider2D enemyAttackCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAttackCollider = GetComponent<CircleCollider2D>();
        enemyAttackCollider.isTrigger = true;
        enemyAttackCollider.radius = enemyRadius;
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

    // Metoda zadająca obrażenia graczowi
    public void DealDamage(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Time.time >= lastAttack + enemyAttackCooldown)
            {
                lastAttack = Time.time;

                Health playerHealth = collision.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.GetHit(enemyDamage, this.gameObject);
                }
            }
        }
    }
}
