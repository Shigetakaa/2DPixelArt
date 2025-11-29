using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DaggerAttack : MonoBehaviour
{
    public float daggerDamage = 2f;
    public Vector2 daggerAttackXY = new Vector2(-0.35f, 0.01f);
    public int pierceNumber = 3;
    public float maxTimeLimit = 3f;
    private float speed;
    private Vector2 direction;
    private float timeLimit;

    private Transform enemy;
    private SpriteRenderer sprite;
    private CapsuleCollider2D daggerAttack;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        daggerAttack = GetComponent<CapsuleCollider2D>();
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

    public void Initialize(Transform enemy, float speed, float angle)
    {
        this.enemy = enemy;
        this.speed = speed;

        if (enemy != null)
        {
            direction = ((Vector2)(enemy.position - transform.position)).normalized;
        }
        else
        {
            direction = Vector2.right;
        }

        direction = Quaternion.Euler(0, 0, angle) * direction;
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
                bossHealth.GetHit(daggerDamage, player);
                PierceCount();
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(daggerDamage, player);
                PierceCount();
            }
        }
    }

    private void PierceCount()
    {
        pierceNumber--;

        if (pierceNumber <= 0)
        {
            Destroy(gameObject);
        }
    }
}
