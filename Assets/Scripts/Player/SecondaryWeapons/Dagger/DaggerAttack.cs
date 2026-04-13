using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DaggerAttack : MonoBehaviour
{
    private float finalDamage;
    public Vector2 daggerAttackXY = new Vector2(-0.35f, 0.01f);
    public int pierceNumber = 3;
    public float maxTimeLimit = 1f;
    private float speed;
    private Vector2 direction;
    private float timeLimit;

    private Transform enemy;
    private SpriteRenderer sprite;
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

    private void DealDamage()
    {
        foreach (Collider2D collision in Physics2D.OverlapCapsuleAll(
            transform.position, 
            daggerAttackXY,
            CapsuleDirection2D.Horizontal,
            0f))
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
}
