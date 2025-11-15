using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BossAttack : MonoBehaviour
{
    public GameObject aoeAttack;
    public float aoeAttackCooldown = 4f;
    public int aoeAmount = 4;
    public Vector2 areaMinPos = new Vector2(-4f, -3f);
    public Vector2 areaMaxPos = new Vector2(4f, 3f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AoeAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AoeAttackCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(aoeAttackCooldown);
            SpawnAoeAttack();
        }
    }

    // Metoda tworzenia aoe
    private void SpawnAoeAttack()
    {
        for(int i = 0; i < aoeAmount; i++)
        {
            Vector2 aoeRange = new Vector2(
                Random.Range(areaMinPos.x, areaMaxPos.x),
                Random.Range(areaMinPos.y, areaMaxPos.y)
            );

            Vector2 spawnAoePos = (Vector2)transform.position + aoeRange;

            GameObject aoe = Instantiate(aoeAttack, spawnAoePos, Quaternion.identity);
            aoe.transform.position = new Vector3(aoe.transform.position.x, spawnAoePos.y, -1f);
        }
    }
}
