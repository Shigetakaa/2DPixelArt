using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject[] bosses;

    public Transform player;
    public GameObject timer;

    public float spawnRadius = 30f;

    private bool bossSpawned = false;
    private Timer timerScript;

    public LayerMask waterLayer;
    public float checkRadius = 0.5f;
    public int spawnAttempts = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerScript = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jak timer jest 0 to metoda Spanwer() się wywołuje
        if(!bossSpawned && timerScript.remainingTime <= 0)
        {
            Spawner();
            bossSpawned = true;
        }
    }

    // Metoda tworzenia bossa
    public void Spawner()
    {
        Vector3 positionSpawn = Vector3.zero;
        bool validPostition = false;

        for (int i = 0; i< spawnAttempts; i++)
        {
            // Losowanie pozycji wroga
            float spawnAngle = Random.Range(0f, Mathf.PI * 2f);
            float spawnDistance = Random.Range(spawnRadius * 0.8f, spawnRadius);
            positionSpawn = player.position + new Vector3(Mathf.Cos(spawnAngle), Mathf.Sin(spawnAngle), 0) * spawnDistance;
            positionSpawn.z = -2f;

            if(!Physics2D.OverlapCircle(positionSpawn, checkRadius, waterLayer))
            {
                validPostition = true;
                break;
            }
        }

        if (!validPostition)
        {
            return;
        }

        // // Losowanie pozycji wroga
        // float spawnAngle = Random.Range(0f, Mathf.PI * 2f);
        // float spawnDistance = Random.Range(spawnRadius * 0.8f, spawnRadius);
        // Vector3 positionSpawn = player.position + new Vector3(Mathf.Cos(spawnAngle), Mathf.Sin(spawnAngle), 0) * spawnDistance;
        // positionSpawn.z = -2f;

        // Losowanie wroga
        int randomSpawn = Random.Range(0, bosses.Length);
        GameObject chosenEnemy = bosses[randomSpawn];

        // Tworzenie wroga
        Instantiate(chosenEnemy, positionSpawn, Quaternion.identity);
    }
}
