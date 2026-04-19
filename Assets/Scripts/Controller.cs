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

    private PlayerStatsMultiplier statsMultiplier;

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
        statsMultiplier = GetComponent<PlayerStatsMultiplier>();
    }

    void Update()
    {
        if(weaponParent != null)
        {
           weaponParent.PointerPosition = attackDirection; 
        }
    }

    private void FixedUpdate()
    {
        // Ruch obiektu
        float finalMoveSpeed = moveSpeed;

        if(statsMultiplier != null)
        {
            finalMoveSpeed *= statsMultiplier.moveSpeedMultiplier;
        }

        rigidbody2D.linearVelocity = new Vector2(moveDirection.x * finalMoveSpeed, moveDirection.y * finalMoveSpeed);
    }
}
