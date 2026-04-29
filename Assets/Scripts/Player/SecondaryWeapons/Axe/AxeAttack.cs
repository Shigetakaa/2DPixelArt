using System;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public float finalDamage;
    public float axeAttackRadius = 2f;
    private float axeRotateSpeed;
    private float timeLimit;
    private float axeRadius;
    private float axeAngle;
    public float axeDamageCooldown = 0.1f;
    private float nextAxeDamage;

    private Transform center;
    private GameObject player;
    private SpriteRenderer sprite;
    public Vector2 hitboxOffset = new Vector2(-0.3f, 0.6f);
    public Transform areaOrigin;
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
        timeLimit -= Time.deltaTime;
        if(timeLimit < 0)
        {
            Destroy(gameObject);
            return;
        }

        axeAngle += axeRotateSpeed * Time.deltaTime;
        float radian = axeAngle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * axeRadius;

        transform.up = offset.normalized;

        transform.position = center.position + offset;

        DealDamage();
    }

    public void Initialize(Transform center, float axeRotateSpeed, float timeLimit, float axeRadius, float axeDamage)
    {
        this.center = center;
        this.axeRotateSpeed = axeRotateSpeed;
        this.timeLimit = timeLimit;
        this.axeRadius = axeRadius;
        this.finalDamage = axeDamage;

        Vector2 diff = transform.position - center.position;
        axeAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = transform.right * hitboxOffset.x +
            transform.up * hitboxOffset.y;
        Gizmos.DrawWireSphere(transform.position + position, axeAttackRadius);
    }

    private void DealDamage()
    {
        if(Time.time < nextAxeDamage) return;

        Vector2 position = (Vector2)(transform.right * hitboxOffset.x +
            transform.up * hitboxOffset.y);

        Vector2 hitboxPosition = (Vector2)transform.position + position;

        foreach (Collider2D collision in Physics2D.OverlapCircleAll(hitboxPosition, axeAttackRadius))
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

        nextAxeDamage = Time.time + axeDamageCooldown;
    }
}
