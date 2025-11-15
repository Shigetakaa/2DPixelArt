using System.Collections;
using UnityEngine;

public class BossAoe : MonoBehaviour
{
    public float aoeDamage = 30f;
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

    private IEnumerator ActivateAoeAttack()
    {
        yield return new WaitForSeconds(warnTime);
        sprite.color = Color.red;
        dealDamage = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DealDaamage(other);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        DealDaamage(other);
    }

    // Metoda zadająca obrażenia graczowi
    public void DealDaamage(Collider2D other)
    {
        if(!dealDamage) return;

        if (other.CompareTag("Player"))
        {
            Health playerHeath = other.GetComponent<Health>();
            if(playerHeath != null)
            {
                playerHeath.GetHit(aoeDamage, this.gameObject);

                dealDamage = false;
            }
            
        }
    }
}
