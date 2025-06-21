using System;
using System.Collections;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    public Animator animator;
    public float cooldown = 0.5f;
    private bool attackBlocked;

    public Transform circleOrigin;
    public float area;

    // Obracanie broni w strone kursora
    private void Update()
    {
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        // Zmiana strony broni np. z lewej na prawą
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
    }

    // Metoda animacji ataku
    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(AttackCooldown());
    }

    // Czekanie na koniec cooldown'u
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        attackBlocked = false;
    }

    // Metoda rysująca Gizmo (powierzchnia ataku)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, area);
    }

    // Metoda sprawdzająca kolizje
    public void DetectColliders()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, area))
        {
            Health health;
            if (health = collider.GetComponent<Health>())
            {
                health.GetHit(2, transform.parent.gameObject);
            }
        }
    }
}
