using System;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public float axeDamage = 2f;
    public float axeAttackRadius = 0.5f;
    private float axeRotateSpeed;
    private float timeLimit;
    private float axeRadius;
    private float axeAngle;
    private float axeDamageCooldown = 0.5f;
    private float nextAxeDamage;

    private Transform center;
    private GameObject player;
    private SpriteRenderer sprite;
    private CircleCollider2D axeAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        axeAttack = GetComponent<CircleCollider2D>();
        axeAttack.isTrigger = true;
        axeAttack.radius = axeAttackRadius;
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
        float radian = axeAngle * Mathf.Rad2Deg;

        Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * axeRadius;
        transform.position = center.position + offset;

        DealDamage();
    }

    public void Initialize(Transform center, float axeRotateSpeed, float timeLimit, float axeRadius)
    {
        this.center = center;
        this.axeRotateSpeed = axeRotateSpeed;
        this.timeLimit = timeLimit;
        this.axeRadius = axeRadius;

        Vector2 diff = transform.position - center.position;
        axeAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }

    private void DealDamage()
    {
        if(Time.time < nextAxeDamage) return;

        foreach (Collider2D collision in Physics2D.OverlapCircleAll(transform.position, axeAttackRadius))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (bossHealth != null)
            {
                bossHealth.GetHit(axeDamage, player);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(axeDamage, player);
            }
        }

        nextAxeDamage = Time.time + axeDamageCooldown;
    }
}
