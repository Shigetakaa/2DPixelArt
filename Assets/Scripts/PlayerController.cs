using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float moveSpeed = 10.0f;
    public InputAction playerControlls;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    void OnDisable()
    {
        playerControlls.Disable();
    }

    void Start()
    {

    }

    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

        // Nasłuchiwanie WSADa
        moveDirection = playerControlls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Ruch gracza
        rigidbody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
