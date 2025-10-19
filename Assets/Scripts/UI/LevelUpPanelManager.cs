using TMPro;
using UnityEngine;

public class LevelUpPanelManager : MonoBehaviour
{
    public TextMeshProUGUI levelUpText;

    public GameObject levelUpScreen;

    WeaponParent weaponParent;
    Health health;
    Exp exp;
    Controller player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        player = FindObjectOfType<Controller>();
        weaponParent = FindObjectOfType<WeaponParent>();
        health = FindObjectOfType<Health>();
        exp = FindObjectOfType<Exp>();

        // Poziom postaci w panelu
        levelUpText.text = "Poziom: " + exp.level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackPress()
    {
        weaponParent.playerDamage += 1f;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnHealtPress()
    {
        health.maxHealth += 5f;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void OnMoveSpeedPress()
    {
        player.moveSpeed += 0.5f;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
