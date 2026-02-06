using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public GameObject daggerAttack;

    public float daggerAttackSpeed = 10f;
    public float daggerAttackCooldown = 2f;

    public Vector2 areaMinPos = new Vector2(-10, -10);
    public Vector2 areaMaxPos = new Vector2(10, 10);

    private string[] enemyTags = {"Enemy", "Boss"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DaggerAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
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

            yield return new WaitForSeconds(daggerAttackCooldown);
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
                Vector2 position = enemy.transform.position;

                if (position.x >= areaMinPos.x && position.x <= areaMaxPos.x &&
                    position.y >= areaMinPos.y && position.y <= areaMaxPos.y)
                {
                    float distance = Vector2.Distance(transform.position, position);

                    if (distance < shortDistance)
                    {
                        shortDistance = distance;
                        closeEnemy = enemy;
                    }
                }
            }
        }
        return closeEnemy;
    }

    private void Throw(Transform enemy)
    {
        float[] angles = {-10f, 0f, 10f};

        foreach (float angle in angles)
        {
            GameObject daggerAttackObject = Instantiate(daggerAttack, transform.position, Quaternion.identity);
            daggerAttackObject.GetComponent<DaggerAttack>().Initialize(enemy, daggerAttackSpeed, angle);
        }
    }
}
