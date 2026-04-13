using System;
using System.Collections;
using UnityEngine;

public class Ring : MonoBehaviour, SecondaryWeaponStats
{
    public GameObject ringAttack;

    public float ringDamage = 10f;
    public float ringAttackCooldown = 4f;
    public float finalCooldown;
    public int attackAmount = 3;
    public float finalNumber;
    public Vector2 areaMinPos = new Vector2(-10f, -10f);
    public Vector2 areaMaxPos = new Vector2(10f, 10f);

    private GameObject player;
    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        StartCoroutine(RingAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        finalNumber = (attackAmount + statsMultiplier.ringNumberBonus) * statsMultiplier.numberMultiplier;
        finalCooldown = ringAttackCooldown * statsMultiplier.cooldownMultiplier;
    }

    private IEnumerator RingAttackCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(finalCooldown);
            SpawnRingAttack();
        }
    }


    private void SpawnRingAttack()
    {
        for (int i = 0; i < finalNumber; i++)
        {
            Vector2 attackPos = new Vector2(
                UnityEngine.Random.Range(areaMinPos.x, areaMaxPos.x),
                UnityEngine.Random.Range(areaMinPos.y, areaMaxPos.y)
            );

            Vector2 spawnAttackPos = (Vector2)transform.position + attackPos;

            Vector3 spawnPos = new Vector3(spawnAttackPos.x, spawnAttackPos.y, -1f);

            GameObject ringAttackObject = Instantiate(ringAttack, spawnPos, Quaternion.identity);
            RingAttack attack = ringAttackObject.GetComponent<RingAttack>();

            attack.Initialize(GetDamage(), player);

            // attack.transform.position = new Vector3(attack.transform.position.x, spawnAttackPos.y, -1f);
        }
    }

    public float GetDamage()
    {
        return (ringDamage + statsMultiplier.ringBonus) * statsMultiplier.damageMultiplier;
    }

    public float GetNumber()
    {
        return finalNumber;
    }

    public float GetCooldown()
    {
        return finalCooldown;
    }
}
