using TMPro;
using UnityEngine;

public class PlayerStatsMultiplier : MonoBehaviour
{
    public float damageMultiplier = 1.0f;
    public float numberMultiplier = 1.0f;
    public float healthMultiplier = 1.0f;
    public float healthRegenMultiplier = 1.0f;
    public float cooldownMultiplier = 1.0f;
    public float moveSpeedMultiplier = 1.0f;
    public float expMultiplier = 1.0f;
    public float itemMagnetMultiplier = 1.0f;
    public float difficultyMultiplier = 1.0f;


    public float axeBonus = 0f;
    public float axeCooldownBonus = 0f;
    public float axeNumberBonus = 0f;

    public float daggerBonus = 0f;
    public float daggerCooldownBonus = 0f;
    public float daggerNumberBonus = 0f;

    public float auraBonus = 0f;
    public float auraCooldownBonus = 0f;

    public float staffBonus = 0f;
    public float staffCooldownBonus = 0f;
    public float staffNumberBonus = 0f;

    public float ringBonus = 0f;
    public float ringCooldownBonus = 0f;
    public float ringNumberBonus = 0f;

    public float swordBonus = 0f;
    public float swordCooldownBonus = 0f;


    public TextMeshProUGUI damageMultiplierText;
    public TextMeshProUGUI cooldownMultiplierText;
    public TextMeshProUGUI moveSpeedMultiplierText;
    public TextMeshProUGUI expMultiplierText;
    public TextMeshProUGUI itemMagnetMultiplierText;
    public TextMeshProUGUI difficultyMultiplierText;
    public TextMeshProUGUI numberMultiplierText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageMultiplierText.text = "x" + damageMultiplier.ToString("F2");
        cooldownMultiplierText.text = "x" + cooldownMultiplier.ToString("F2");
        moveSpeedMultiplierText.text = "x" + moveSpeedMultiplier.ToString("F2");
        expMultiplierText.text = "x" + expMultiplier.ToString("F2");
        itemMagnetMultiplierText.text = "x" + itemMagnetMultiplier.ToString("F2");
        difficultyMultiplierText.text = "x" + difficultyMultiplier.ToString("F2");
        numberMultiplierText.text = "x" + numberMultiplier.ToString("F2");
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

    public void AddExpBonus(float bonus)
    {
        expMultiplier += bonus;
    }

    public void AddItemMagnetBonus(float bonus)
    {
        itemMagnetMultiplier += bonus;
    }

    public void AddDifficultyBonus(float bonus)
    {
        difficultyMultiplier += bonus;
    }
}
