using System.Collections;
using UnityEngine;

public class RingAttack : MonoBehaviour
{

    public float finalDamage;
    public float ringAttackRadius = 0.3f;
    public float warnTime = 2f;

    private SpriteRenderer sprite;
    public Transform areaOrigin;
    public Animator animator;
    private CircleCollider2D ringAttack;

    public GameObject player;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        ringAttack = GetComponent<CircleCollider2D>();
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        ringAttack.isTrigger = true;
        ringAttack.radius = ringAttackRadius;

        StartCoroutine(ActivateRingAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(float ringDamage, GameObject player)
    {
        this.finalDamage = ringDamage;
        this.player = player;
    }

    private IEnumerator ActivateRingAttack()
    {
        yield return new WaitForSeconds(warnTime);
        Attack();
        yield return new WaitForSeconds(0.5f);
        DealDamage();
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = areaOrigin == null ? Vector3.zero : areaOrigin.position;
        Gizmos.DrawWireSphere(position, ringAttackRadius);
    }

    public void DealDamage()
    {
        foreach (Collider2D collision in Physics2D.OverlapCircleAll(transform.position, ringAttackRadius))
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

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
