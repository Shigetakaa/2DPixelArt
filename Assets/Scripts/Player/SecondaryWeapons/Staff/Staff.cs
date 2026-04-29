using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Staff : MonoBehaviour, SecondaryWeaponStats
{
    public GameObject staffAttack;

    public float staffDamage = 4f;
    public float staffAttackCooldown = 4f;
    public float minCooldown = 0.1f;
    public float finalCooldown;
    public float staffAttackSpeed = 10f;
    public int staffNumber = 1;
    public int finalNumber;
    
    public Vector2 areaMinPos = new Vector2(-10f, -10f);
    public Vector2 areaMaxPos = new Vector2(10f, 10f);

    private string[] enemyTags = {"Enemy", "Boss"};

    private GameObject player;
    private PlayerStatsMultiplier statsMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statsMultiplier = player.GetComponent<PlayerStatsMultiplier>();

        StartCoroutine(StaffAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        finalNumber = Mathf.RoundToInt((staffNumber + statsMultiplier.staffNumberBonus) * statsMultiplier.numberMultiplier);
        finalCooldown = staffAttackCooldown * statsMultiplier.cooldownMultiplier;
        finalCooldown = Mathf.Max(minCooldown, finalCooldown);
    }

    private IEnumerator StaffAttackCooldown()
    {
        while (true)
        {
            GameObject enemy = FindEnemy();

            if(enemy != null)
            {
                StartCoroutine(Shoot(enemy));
            }

            yield return new WaitForSeconds(finalCooldown);
        }
    }

    public GameObject FindEnemy()
    {
        GameObject closeEnemy = null;
        float shortDistance = Mathf.Infinity;

        foreach (string tag in enemyTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject enemy in enemies)
            {
                // Vector2 position = enemy.transform.position;

                // if (position.x >= areaMinPos.x && position.x <= areaMaxPos.x &&
                //     position.y >= areaMinPos.y && position.y <= areaMaxPos.y)
                // {
                    float distance = Vector2.Distance(transform.position, enemy.transform.position);

                    if(distance <= shortDistance)
                    {
                        shortDistance = distance;
                        closeEnemy = enemy;
                    }
                // }
            }
        }
        return closeEnemy;  
    }

    private IEnumerator Shoot(GameObject enemy)
    {
        for(int i = 0; i < finalNumber; i++)
        {
            GameObject staffAttackObject = Instantiate(staffAttack, transform.position, Quaternion.identity);
            staffAttackObject.GetComponent<StaffAttack>().Initialize(enemy.transform, staffAttackSpeed, GetDamage(), this);

            yield return new WaitForSeconds(0.2f);
        }
    }

    public float GetDamage()
    {
        return (staffDamage + statsMultiplier.staffBonus) * statsMultiplier.damageMultiplier;
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
