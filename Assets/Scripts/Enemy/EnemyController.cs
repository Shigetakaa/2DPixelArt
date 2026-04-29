using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement, OnPointer;
    public UnityEvent OnAttack;

    public Transform player;

    public float chaseDistance = 200, attackDistance = 0.8f;

    public LayerMask waterLayer;
    public float waterDistance = 3f;

    private void Start()
    {
        // Znajdowania gracza po tagu
        if (player == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }


    private void Update()
    {
        if (player == null)
            return;

        // Dystans pomiędzy wrogiem a graczem
        float distance = Vector2.Distance(player.position, transform.position);

        // Czy gracz jest w zasięgu
        if (distance < chaseDistance)
        {
            // Skierowanie wroga w strone gracza
            OnPointer?.Invoke(player.position);

            if (distance <= attackDistance)
            {
                // Atakowanie gracza
                OnMovement?.Invoke(Vector2.zero);
            }
            else
            {
                // Ruch w strone gracza
                Vector2 direction = (player.position - transform.position).normalized;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, waterDistance, waterLayer);

                Color rayColor = hit.collider != null ? Color.blue : Color.red;
                Debug.DrawRay(transform.position, direction * waterDistance, rayColor);

                // Skręt gdy wykrywa wode
                if(hit.collider != null)
                {
                    Vector2 left = new Vector2(-direction.y, direction.x);
                    Vector2 right = new Vector2(direction.y, -direction.x);

                    RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, left, waterDistance, waterLayer);
                    RaycastHit2D hitRight = Physics2D.Raycast(transform.position, right, waterDistance, waterLayer);

                    Debug.DrawRay(transform.position, left * waterDistance, Color.blue);
                    Debug.DrawRay(transform.position, right * waterDistance, Color.blue);

                    if(hitLeft.collider == null)
                    {
                        OnMovement?.Invoke(left.normalized);
                    }
                    else if( hitRight.collider == null)
                    {
                        OnMovement?.Invoke(right.normalized);
                    }
                    else
                    {
                        OnMovement?.Invoke(-direction);
                    }
                }
                else
                {
                    OnMovement?.Invoke(direction);
                }
            }
        }
    }
}
