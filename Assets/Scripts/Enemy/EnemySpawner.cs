using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public Transform player;
    public GameObject timer;

    private bool spawnOn = true;

    public float spawnRadius = 30f;

    public float spawnCooldown = 1f;
    private float spawnTime;

    private Timer timerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = spawnCooldown;
        spawnOn = true;
        timerScript = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jak timer jest 0 to metoda Spanwer() się nie wywołuje oraz wszyscy wrogowie giną
        if(timerScript.remainingTime <= 0)
        {
            KillAllEnemies();
            return;
        }

        // Odliczanie
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }

        // Wróg się pojawia po upłynięciu czasu
        if (spawnTime <= 0)
        {
            Spawner();
            spawnTime = spawnCooldown;
        }
    }
    
    // Metoda tworzenia wroga
    public void Spawner()
    {
        // Losowanie pozycji wroga
        float spawnAngle = Random.Range(0f, Mathf.PI * 2f);
        float spawnDistance = Random.Range(spawnRadius * 0.8f, spawnRadius);
        Vector3 positionSpawn = player.position + new Vector3(Mathf.Cos(spawnAngle), Mathf.Sin(spawnAngle), 0) * spawnDistance;
        positionSpawn.z = -1f;

        // Losowanie wroga
        int randomSpawn = Random.Range(0, enemies.Length);
        GameObject chosenEnemy = enemies[randomSpawn];

        // Tworzenie wroga
        GameObject spawned = Instantiate(chosenEnemy, positionSpawn, Quaternion.identity);
    }

    public void KillAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
