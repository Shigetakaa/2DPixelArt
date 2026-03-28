using System;
using System.Collections;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameObject ringAttack;
    public float ringAttackCooldown = 4f;
    public int attackAmount = 5;
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
        
    }

    private IEnumerator RingAttackCooldown()
    {
        float finalCooldown = ringAttackCooldown * statsMultiplier.cooldownMultiplier;

        while (true)
        {
            yield return new WaitForSeconds(finalCooldown);
            SpawnRingAttack();
        }
    }


    private void SpawnRingAttack()
    {
        for (int i = 0; i < attackAmount; i++)
        {
            Vector2 attackPos = new Vector2(
                UnityEngine.Random.Range(areaMinPos.x, areaMaxPos.x),
                UnityEngine.Random.Range(areaMinPos.y, areaMaxPos.y)
            );

            Vector2 spawnAttackPos = (Vector2)transform.position + attackPos;

            GameObject attack = Instantiate(ringAttack, spawnAttackPos, Quaternion.identity);
            attack.transform.position = new Vector3(attack.transform.position.x, spawnAttackPos.y, -1f);
        }
    }
}
