using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DaggerAttack : MonoBehaviour
{
    private float finalDamage;
    public float daggerAttackRadius = 0.3f;
    public int pierceNumber = 3;
    public float maxTimeLimit = 1f;
    private float speed;
    private Vector2 direction;
    private float timeLimit;
    public float daggerDamageCooldown = 0.1f;
    private float nextDaggerDamage;

    private Transform enemy;
    private SpriteRenderer sprite;
    public Vector2 hitboxOffset = new Vector2(-1.4f, 0f);
    public Transform areaOrigin;
    private CapsuleCollider2D daggerAttack;

    public GameObject player;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        daggerAttack = GetComponent<CapsuleCollider2D>();
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        daggerAttack.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit += Time.deltaTime;

        if (timeLimit >= maxTimeLimit)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += (Vector3)direction * speed * Time.deltaTime;

        DealDamage();
    }

    public void Initialize(Transform enemy, float speed, float angle, float daggerDamage)
    {
        this.enemy = enemy;
        this.speed = speed;
        this.finalDamage = daggerDamage;

        if (enemy != null)
        {
            direction = ((Vector2)(enemy.position - transform.position)).normalized;
        }
        else
        {
            direction = Vector2.right;
        }

        direction = Quaternion.Euler(0, 0, angle) * direction;

        transform.right = -direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = transform.right * hitboxOffset.x +
            transform.up * hitboxOffset.y;
        Gizmos.DrawWireSphere(transform.position + position, daggerAttackRadius);
    }

    private void DealDamage()
    {
        if(Time.time < nextDaggerDamage) return;

        Vector2 position = (Vector2)(transform.right * hitboxOffset.x +
            transform.up * hitboxOffset.y);

        Vector2 hitboxPosition = (Vector2)transform.position + position;

        foreach (Collider2D collision in Physics2D.OverlapCircleAll(hitboxPosition, daggerAttackRadius))
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

        nextDaggerDamage = Time.time + daggerDamageCooldown;
    }
}
