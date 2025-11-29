using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    public float staffDamage = 10f;
    public float staffAttackRadius = 0.03f;
    private float speed;

    private Transform enemy;
    private SpriteRenderer sprite;
    private CircleCollider2D staffAttack;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        staffAttack = GetComponent<CircleCollider2D>();
        staffAttack.isTrigger = true;
        staffAttack.radius = staffAttackRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (enemy.position - transform.position).normalized;

        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, enemy.position) < 0.1f)
        {
            DealDamage();
            Destroy(gameObject);
        }
    }

    public void Initialize(Transform enemy, float speed)
    {
        this.enemy = enemy;
        this.speed = speed;
    }

    public void DealDamage()
    {
        foreach (Collider2D collision in Physics2D.OverlapCircleAll(transform.position, staffAttackRadius))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (bossHealth != null)
            {
                bossHealth.GetHit(staffDamage, player);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(staffDamage, player);
            }
        }
    }
}
