using UnityEngine;

public class StaffAttack : MonoBehaviour
{
    public float finalDamage;
    public float staffAttackRadius = 0.3f;
    private float speed;

    private Transform enemy;
    private SpriteRenderer sprite;
    public Vector2 hitboxOffset = new Vector2(0.05f, 0.05f);
    public Transform areaOrigin;

    public GameObject player;
    private Staff staff;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();

        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
        {
            if(staff != null)
            {
                GameObject newEnemy = staff.FindEnemy();
                enemy = newEnemy != null ? newEnemy.transform : null;
            }

            if(enemy == null)
            {
                Destroy(gameObject);
                return;
            }
        }

        Vector2 direction = (enemy.position - transform.position).normalized;

        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, enemy.position) < 0.1f)
        {
            DealDamage();
            Destroy(gameObject);
        }
    }

    public void Initialize(Transform enemy, float speed, float staffDamage, Staff staff)
    {
        this.enemy = enemy;
        this.speed = speed;
        this.finalDamage = staffDamage;
        this.staff = staff;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = transform.right * hitboxOffset.x +
            transform.up * hitboxOffset.y;
        Gizmos.DrawWireSphere(transform.position + position, staffAttackRadius);
    }

    public void DealDamage()
    {
        Vector2 position = (Vector2)(transform.right * hitboxOffset.x +
            transform.up * hitboxOffset.y);

        Vector2 hitboxPosition = (Vector2)transform.position + position;

        foreach (Collider2D collision in Physics2D.OverlapCircleAll(hitboxPosition, staffAttackRadius))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (bossHealth != null)
            {
                bossHealth.GetHit(finalDamage, gameObject);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(finalDamage, gameObject);
            }
        }
    }
}
