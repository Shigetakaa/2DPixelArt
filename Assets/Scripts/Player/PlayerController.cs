using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject characterStats;
    public GameObject characterParameters;
    public GameObject equipmentPanel;

    public UnityEvent<Vector2> OnMovement, OnPointer;
    public UnityEvent OnAttack;

    // Wczytanie przycisków
    public InputActionReference movement, attack, pointerPosition, pause;

    public CircleCollider2D magnet;

    public Vector2 minBounds = new Vector2(-208f, -150f);
    public Vector2 maxBounds = new Vector2(233f, 142f);

    public float magnetRadius = 3f;

    void Start()
    {
        UpdateMagnetRange();
    }

    public void UpdateMagnetRange()
    {
        magnet.radius = magnetRadius;
    }

    private void Update()
    {
        // Ruch postaci gracza
        OnMovement?.Invoke(movement.action.ReadValue<Vector2>());
        // Wczytanie pozycji kursora
        OnPointer?.Invoke(GetAttackDirection());
    }

    void LateUpdate()
    {
        // Okroślenie obszaru po którym gracz może się poruszać
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        position.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);

        transform.position = position;
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
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            characterStats.SetActive(true);
            characterParameters.SetActive(false);
            equipmentPanel.SetActive(false);
            // Wyłączenie pauzy
            pauseMenu.SetActive(false);
        }
        else
        {
            // Zatrzymywanie czasu
            Time.timeScale = 0;
            characterStats.SetActive(false);
            characterParameters.SetActive(true);
            equipmentPanel.SetActive(true);
            // Aktywowanie menu pauzy
            pauseMenu.SetActive(true);
        }
    }
}
