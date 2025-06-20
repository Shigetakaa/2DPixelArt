using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float moveSpeed = 10.0f;

    public float attackCooldown = 0.5f;
    private float lastAttackTime = 0f;

    Vector2 moveDirection = Vector2.zero;
    Vector2 attackDirection = Vector2.zero;

    // Zdefiniowanie akcji
    public InputActionReference movement, attack, pointerPosition;

    void Start()
    {

    }

    void Update()
    {
        // Nasłuchiwanie WSADa
        moveDirection = movement.action.ReadValue<Vector2>();
        // Nasłuchiwanie lewego przycisku myszki
        attackDirection = attack.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Ruch gracza
        rigidbody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
