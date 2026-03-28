using System;
using System.Collections;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public GameObject axeAttack;

    public int axeNumber = 8;
    public float axeSpawnRadius = 1.5f;
    public float axeRotateSpeed = 10f;
    public float timeLimit = 4f;
    public float axeAttackCooldown = 4f;

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
        
    }

    private IEnumerator AxeAttackCooldown()
    {
        float finalCooldown = axeAttackCooldown * statsMultiplier.cooldownMultiplier;

        while (true)
        {
            SpawnAxeAttack();
            yield return new WaitForSeconds(finalCooldown);
        }
    }

    private void SpawnAxeAttack()
    {
        float axeAngle = 360f / axeNumber;

        for(int i = 0; i < axeNumber; i++)
        {
            float angle = i * axeAngle;

            Vector2 offset = Quaternion.Euler(0, 0, angle) * Vector2.right * axeSpawnRadius;
            Vector3 axeSpawnPos = transform.position + (Vector3)offset;

            GameObject axeAttackObject = Instantiate(axeAttack, axeSpawnPos, Quaternion.identity);

            axeAttackObject.GetComponent<AxeAttack>().Initialize(
                this.transform,
                axeRotateSpeed,
                timeLimit,
                axeSpawnRadius
            );
        }
    }
}
