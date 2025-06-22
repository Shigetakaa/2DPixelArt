using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement, OnPointer;
    public UnityEvent OnAttack;

    // Zdefiniowanie akcji
    public InputActionReference movement, attack, pointerPosition;

    private void Update()
    {
        // Wczytanie WSADa
        OnMovement?.Invoke(movement.action.ReadValue<Vector2>());
        // Wczytanie pozycji kursora
        OnPointer?.Invoke(GetAttackDirection());
    }

    // Metoda wczytująca pozycje kursora
    private Vector2 GetAttackDirection()
    {
        // Wczytanie pozycji kursora
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnEnable()
    {
        // Aktywowanie metody ataku po kliknięciu na lewy przycisk myszy
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    // Metoda ataku
    private void PerformAttack(InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke();
    }
}
