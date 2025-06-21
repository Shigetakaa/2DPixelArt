using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float moveSpeed = 10.0f;

    private Vector2 moveDirection, attackDirection;

    // Zdefiniowanie akcji
    public InputActionReference movement, attack, pointerPosition;

    private WeaponParent weaponParent;

    private void OnEnable()
    {
        // Aktywowanie metody ataku po kliknięciu na lewy przycisk myszy
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    // Pobranie metody ataku z WeaponParent
    private void PerformAttack(InputAction.CallbackContext obj)
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
        // Wczytanie WSADa
        moveDirection = movement.action.ReadValue<Vector2>();
        // Wczytanie pozycji kursora
        attackDirection = GetAttackDirection();
        weaponParent.PointerPosition = attackDirection;
    }

    private Vector2 GetAttackDirection()
    {
        // Wczytanie pozycji kursora
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void FixedUpdate()
    {
        // Ruch gracza
        rigidbody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


}
