using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public GameObject staffAttack;

    public float staffAttackCooldown = 4f;
    public float staffAttackSpeed = 10f;
    
    public Vector2 areaMinPos = new Vector2(-10f, -10f);
    public Vector2 areaMaxPos = new Vector2(10f, 10f);

    private string[] enemyTags = {"Enemy", "Boss"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StaffAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StaffAttackCooldown()
    {
        while (true)
        {
            GameObject enemy = FindEnemy();
    
            if(enemy != null)
            {
                Shoot(enemy);
            }

            yield return new WaitForSeconds(staffAttackCooldown);
        }
    }

    private GameObject FindEnemy()
    {
        GameObject closeEnemy = null;
        float shortDistance = Mathf.Infinity;

        foreach (string tag in enemyTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject enemy in enemies)
            {
                Vector2 position = enemy.transform.position;

                if (position.x >= areaMinPos.x && position.x <= areaMaxPos.x &&
                    position.y >= areaMinPos.y && position.y <= areaMaxPos.y)
                {
                    float distance = Vector2.Distance(transform.position, position);

                    if(distance <= shortDistance)
                    {
                        shortDistance = distance;
                        closeEnemy = enemy;
                    }
                }
            }
        }
        return closeEnemy;  
    }

    private void Shoot(GameObject enemy)
    {
        GameObject staffAttackObject = Instantiate(staffAttack, transform.position, Quaternion.identity);
        staffAttackObject.GetComponent<StaffAttack>().Initialize(enemy.transform, staffAttackSpeed);
    }
}
