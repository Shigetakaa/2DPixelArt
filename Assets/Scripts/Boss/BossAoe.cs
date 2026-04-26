using System.Collections;
using UnityEngine;

public class BossAoe : MonoBehaviour
{
    public float aoeDamage = 20.0f;
    public float aoeRadius = 0.3f;
    public float warnTime = 1f;

    private SpriteRenderer sprite;
    private CircleCollider2D aoeAttack;
    public Animator animator;
    public bool dealDamage = false;

    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        aoeAttack = GetComponent<CircleCollider2D>();
        statsMultiplier = GameObject.FindWithTag("Player").GetComponent<PlayerStatsMultiplier>();

        aoeAttack.isTrigger = true;
        aoeAttack.radius = aoeRadius;

        GetDifficulty();

        StartCoroutine(ActivateAoeAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDifficulty()
    {
        switch (GameSettingsManager.Instance.chosenDifficulty)
        {
            case Difficulty.Easy:
                aoeDamage = 20.0f;
                break;

            case Difficulty.Normal:
                aoeDamage = 40.0f;
                break;

            case Difficulty.Hard:
                aoeDamage = 60.0f;
                break;
        }
    }

    private IEnumerator ActivateAoeAttack()
    {
        yield return new WaitForSeconds(warnTime);
        Attack();
        dealDamage = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
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
        if(!dealDamage) return;

        float finalDamage = aoeDamage * statsMultiplier.difficultyMultiplier;

        if (collision.CompareTag("Player"))
        {
            Health playerHeath = collision.GetComponent<Health>();
            if(playerHeath != null)
            {
                playerHeath.GetHit(finalDamage, this.gameObject);

                dealDamage = false;
            }
            
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void ActivateAoeAnimation()
    {
        dealDamage = true;
    }
}
