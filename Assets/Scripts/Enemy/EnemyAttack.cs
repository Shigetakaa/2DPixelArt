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

    void OnTriggerEnter2D(Collider2D other)
    {
        DealDamage(other);    
    }
    void OnTriggerStay2D(Collider2D other)
    {
        DealDamage(other);
    }

    // Metoda zadająca obrażenia graczowi
    public void DealDamage(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Time.time >= lastAttack + enemyAttackCooldown)
            {
                lastAttack = Time.time;

                Health playerHealth = other.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.GetHit(enemyDamage, this.gameObject);
                }
            }
        }
    }
}
