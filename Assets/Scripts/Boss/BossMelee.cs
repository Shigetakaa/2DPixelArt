using System.Collections;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public GameObject meleeAttack;
    public float meleeDamage = 10.0f;
    public float meleeRadius = 0.8f;
    public float meleeAttackCooldown = 0.5f;
    private float lastAttack;

    private CircleCollider2D meleeAttackCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAttackCollider = GetComponent<CircleCollider2D>();
        meleeAttackCollider.isTrigger = true;
        meleeAttackCollider.radius = meleeRadius;

        //StartCoroutine(ActivateMeleeAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDifficulty()
    {
        switch (GameSettingsManager.Instance.chosenDifficulty)
        {
            case Difficulty.Easy:
                meleeDamage = 10.0f;
                break;

            case Difficulty.Normal:
                meleeDamage = 20.0f;
                break;

            case Difficulty.Hard:
                meleeDamage = 40.0f;
                break;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);    
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        DealDamage(collision);
    }

    // Metoda zadająca obrażenia graczowi
    public void DealDamage(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Time.time >= lastAttack + meleeAttackCooldown)
            {
                lastAttack = Time.time;

                Health playerHealth = collision.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.GetHit(meleeDamage, this.gameObject);
                }
            }
        }
    }
}
