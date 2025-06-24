using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject pauseMenu;

    public UnityEvent<Vector2> OnMovement, OnPointer;
    public UnityEvent OnAttack;

    // Wczytanie przycisków
    public InputActionReference movement, attack, pointerPosition, pause;

    private void Update()
    {
        // Ruch postaci gracza
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
        // Aktywowanie metody pauzy po kliknięciu na esc
        pause.action.performed += ShowPause;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        pause.action.performed -= ShowPause;
    }

    // Metoda ataku
    private void PerformAttack(InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke();
    }

    public void ShowPause(InputAction.CallbackContext context)
    {
        // Zatrzymywanie czasu
        Time.timeScale = 0;
        // Aktywowanie menu pauzy
        pauseMenu.SetActive(true);
    }
}
