using System.Collections;
using UnityEngine;

public class BossAoe : MonoBehaviour
{
    public float aoeDamage = 30f;
    public float aoeRadius = 2.5f;
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

        transform.localScale = new Vector3(aoeRadius * 2f, aoeRadius * 2f, 1f);

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


    // Metoda zadająca obrażenia graczowi
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!dealDamage) return;

        if (other.CompareTag("Player"))
        {
            Health playerHeath = other.GetComponent<Health>();
            if(playerHeath != null)
            {
                playerHeath.GetHit(aoeDamage, this.gameObject);
            }
            
        }
    }

    // Metoda rysująca Gizmo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
