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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AxeAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AxeAttackCooldown()
    {
        while (true)
        {
            SpawnAxeAttack();
            yield return new WaitForSeconds(axeAttackCooldown);
        }
    }

    private void SpawnAxeAttack()
    {
        float axeAngle = 360f / axeNumber;

        for(int i = 0; i < axeNumber; i++)
        {
            float angle = i*axeAngle;

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
