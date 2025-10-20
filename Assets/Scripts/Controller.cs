using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float moveSpeed = 10.0f;

    private Vector2 moveDirection, attackDirection;

    public Vector2 AttackDirection { get => attackDirection; set => attackDirection = value; }
    public Vector2 MoveDirection { get => moveDirection; set => moveDirection = value; }

    private WeaponParent weaponParent;

    public TextMeshProUGUI moveSpeedText;

    // Pobranie metody ataku z WeaponParent
    public void PerformAttack()
    {
        weaponParent.Attack();
    }

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void Start()
    {

    }

    void Update()
    {
        weaponParent.PointerPosition = attackDirection;

        // Wartość prędkości ruchu na ekranie
        moveSpeedText.text = "Prędkość ruchu: " + moveSpeed;
    }

    private void FixedUpdate()
    {
        // Ruch obiektu
        rigidbody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
