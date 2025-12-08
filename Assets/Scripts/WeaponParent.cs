using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    public Animator animator;
    public float cooldown = 0.5f;
    private bool attackBlocked;

    public Transform areaOrigin;
    public float area;
    public float playerDamage = 4;

    public TextMeshProUGUI playerDamageText;
    public TextMeshProUGUI playerDamageCooldownText;

    public TextMeshProUGUI playerDamagePauseText;
    public TextMeshProUGUI playerDamageCooldownPauseText;

    private void Update()
    {
        // Obracanie broni w strone kursora
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        // Zmiana strony broni
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;


        // Wartość ataku
        playerDamageText.text = "Atak: " + playerDamage;

        // Wartość cooldownu ataku
        playerDamageCooldownText.text = "Cooldown ataku: " + cooldown.ToString("F2") + "s";


        // Wartość ataku
        playerDamagePauseText.text = "Atak: " + playerDamage;

        // Wartość cooldownu ataku
        playerDamageCooldownPauseText.text = "Cooldown ataku: " + cooldown.ToString("F2") + "s";
    }

    // Metoda animacji ataku
    public void Attack()
    {
        if (attackBlocked)
        {
            return;
        }
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(AttackCooldown());
    }

    // Cooldown ataku
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        attackBlocked = false;
    }

    // Metoda rysująca Gizmo (powierzchnia ataku)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = areaOrigin == null ? Vector3.zero : areaOrigin.position;
        Gizmos.DrawWireSphere(position, area);
    }

    // Metoda zadająca obrażenia
    public void DealDamage()
    {
        foreach (Collider2D collision in Physics2D.OverlapCircleAll(areaOrigin.position, area))
        {
            BossHealth bossHealth = collision.GetComponent<BossHealth>();
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (bossHealth != null)
            {
                bossHealth.GetHit(playerDamage, transform.parent.gameObject);
            }
            else if (enemyHealth != null)
            {
                enemyHealth.GetHit(playerDamage, transform.parent.gameObject);
            }
        }
    }
}
