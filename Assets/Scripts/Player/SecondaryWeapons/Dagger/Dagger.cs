using System;
using System.Collections;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class Dagger : MonoBehaviour, SecondaryWeaponStats
{
    public GameObject daggerAttack;

    public float daggerDamage = 2f;
    public int daggerNumber = 1;
    public float finalNumber;
    public float daggerAttackSpeed = 10f;
    public float daggerAttackCooldown = 2f;
    float finalCooldown;

    public Vector2 areaMinPos = new Vector2(-10, -10);
    public Vector2 areaMaxPos = new Vector2(10, 10);

    private string[] enemyTags = {"Enemy", "Boss"};

    private GameObject player;
    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        StartCoroutine(DaggerAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        finalNumber = (daggerNumber + statsMultiplier.daggerNumberBonus) * statsMultiplier.numberMultiplier;
        finalCooldown = (daggerAttackCooldown + statsMultiplier.daggerCooldownBonus) * statsMultiplier.cooldownMultiplier;
    }

    private IEnumerator DaggerAttackCooldown()
    {
        while (true)
        {
            GameObject enemy = FindEnemy();

            if(enemy != null)
            {
                Throw(enemy.transform);
            }

            yield return new WaitForSeconds(finalCooldown);
        }
    }

    private GameObject FindEnemy()
    {
        GameObject closeEnemy = null;
        float shortDistance = Mathf.Infinity;

        foreach (string tag in enemyTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            foreach(GameObject enemy in enemies)
            {
                // Vector2 position = enemy.transform.position;

                // if (position.x >= areaMinPos.x && position.x <= areaMaxPos.x &&
                //     position.y >= areaMinPos.y && position.y <= areaMaxPos.y)
                // {
                    float distance = Vector2.Distance(transform.position, enemy.transform.position);

                    if (distance < shortDistance)
                    {
                        shortDistance = distance;
                        closeEnemy = enemy;
                    }
                // }
            }
        }
        return closeEnemy;
    }

    private void Throw(Transform enemy)
    {
        float spread = Mathf.Clamp(20f + finalNumber * 4f, 20f, 100f);

        float angleStep = 0f;

        if(finalNumber > 1)
        {
            angleStep = spread / (finalNumber - 1);
        }

        float startAngle = -spread / 2;

        for(int i = 0; i < finalNumber; i++)
        {
            float angle;

            if(finalNumber == 1)
            {
                angle = 0f;
            }
            else
            {
                angle = startAngle + (i * angleStep);
            }

            GameObject daggerAttackObject = Instantiate(daggerAttack, transform.position, Quaternion.identity);
            daggerAttackObject.GetComponent<DaggerAttack>().Initialize(enemy, daggerAttackSpeed, angle, GetDamage());
        }
    }

    public float GetDamage()
    {
        return (daggerDamage + statsMultiplier.daggerBonus) * statsMultiplier.damageMultiplier;
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
