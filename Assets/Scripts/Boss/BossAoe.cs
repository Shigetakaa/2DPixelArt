using System.Collections;
using UnityEngine;

public class BossAoe : MonoBehaviour
{
    public float aoeDamage = 30.0f;
    public float aoeRadius = 0.3f;
    public float warnTime = 1f;

    private SpriteRenderer sprite;
    private CircleCollider2D aoeAttack;
    public bool dealDamage = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        aoeAttack = GetComponent<CircleCollider2D>();
        aoeAttack.isTrigger = true;
        aoeAttack.radius = aoeRadius;

        sprite.color = new Color(1f, 0f, 0f, 0.35f);

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
                aoeDamage = 30.0f;
                break;

            case Difficulty.Normal:
                aoeDamage = 50.0f;
                break;

            case Difficulty.Hard:
                aoeDamage = 70.0f;
                break;
        }
    }

    private IEnumerator ActivateAoeAttack()
    {
        yield return new WaitForSeconds(warnTime);
        sprite.color = Color.red;
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

        if (collision.CompareTag("Player"))
        {
            Health playerHeath = collision.GetComponent<Health>();
            if(playerHeath != null)
            {
                playerHeath.GetHit(aoeDamage, this.gameObject);

                dealDamage = false;
            }
            
        }
    }
}
