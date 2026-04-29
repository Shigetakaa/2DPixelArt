using System;
using System.Collections;
using UnityEngine;

public class Axe : MonoBehaviour, SecondaryWeaponStats
{
    public GameObject axeAttack;

    public float axeDamage = 2f;
    public int axeNumber = 2;
    public int finalNumber;
    public float axeSpawnRadius = 1.5f;
    public float axeRotateSpeed = 10f;
    public float timeLimit = 4f;
    public float axeAttackCooldown = 4f;
    public float minCooldown = 0.1f;
    public float finalCooldown;

    private GameObject player;
    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        StartCoroutine(AxeAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        finalNumber = Mathf.RoundToInt((axeNumber + statsMultiplier.axeNumberBonus) * statsMultiplier.numberMultiplier);
        finalCooldown = axeAttackCooldown * statsMultiplier.cooldownMultiplier;
        finalCooldown = Mathf.Max(minCooldown, finalCooldown);
    }

    private IEnumerator AxeAttackCooldown()
    {
        while (true)
        {
            SpawnAxeAttack();
            yield return new WaitForSeconds(finalCooldown);
        }
    }

    private void SpawnAxeAttack()
    {
        float axeAngle = 360f / finalNumber;

        for(int i = 0; i < finalNumber; i++)
        {
            float angle = i * axeAngle;

            Vector2 offset = Quaternion.Euler(0, 0, angle) * Vector2.right * axeSpawnRadius;
            Vector3 axeSpawnPos = transform.position + (Vector3)offset;

            GameObject axeAttackObject = Instantiate(axeAttack, axeSpawnPos, Quaternion.identity);

            axeAttackObject.GetComponent<AxeAttack>().Initialize(
                this.transform,
                axeRotateSpeed,
                timeLimit,
                axeSpawnRadius,
                GetDamage()
            );
        }
    }

    public float GetDamage()
    {
        return (axeDamage + statsMultiplier.axeBonus) * statsMultiplier.damageMultiplier;
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
