using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement, OnPointer;
    public UnityEvent OnAttack;

    public Transform player;

    public float chaseDistance = 200, attackDistance = 0.8f;

    public float attackCooldown = 1;
    public float passedTime = 1;

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
                if (passedTime >= attackCooldown)
                {
                    passedTime = 0;
                    OnAttack?.Invoke();
                }
            }
            else
            {
                // Ruch w strone gracza
                Vector2 direction = player.position - transform.position;

                OnMovement?.Invoke(direction.normalized);
            }
        }

        // Zmniejszanie czasu oczekiwania na atak
        if (passedTime < attackCooldown)
        {
            passedTime += Time.deltaTime;
        }
    }
}
