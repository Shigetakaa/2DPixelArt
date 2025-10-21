using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement, OnPointer;
    public UnityEvent OnAttack;

    public Transform player;

    public float chaseDistance = 20, attackDistance = 0.8f;

    public float attackCooldown = 0.2f;
    public float passedTime = 0.2f;

    private void Start()
    {
        // Znajdowania gracza po tagu
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning($"{name}: Nie znaleziono gracza z tagiem 'Player'!");
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
