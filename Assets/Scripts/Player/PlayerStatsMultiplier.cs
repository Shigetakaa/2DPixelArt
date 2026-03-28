using UnityEngine;

public class PlayerStatsMultiplier : MonoBehaviour
{
    public float damageMultiplier = 1.0f;
    public float healthMultiplier = 1.0f;
    public float healthRegenMultiplier = 1.0f;
    public float cooldownMultiplier = 1.0f;
    public float moveSpeedMultiplier = 1.0f;
    public float expMultiplier = 1.0f;
    public float itemMagnetMultiplier = 1.0f;
    public float difficultyMultiplier = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamageBonus(float bonus)
    {
        damageMultiplier += bonus;
    }

    public void AddAttackCooldownBonus(float bonus)
    {
        cooldownMultiplier -= bonus;
    }

    public void AddMoveSpeedBonus(float bonus)
    {
        moveSpeedMultiplier += bonus;
    }
}
