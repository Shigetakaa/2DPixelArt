using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject chest;
    public int chestNumber = 3;
    public SecondaryWeaponsManager secondaryWeapons;
    public ChestUIManager chestUI;

    public Vector2 chestMinPos = new Vector2(-7f, -7f);
    public Vector2 chestMaxPos = new Vector2(7f, 7f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChestSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChestSpawner()
    {
        for(int i = 0; i < chestNumber; i++)
        {
            Vector2 chestPos = new Vector2(
                Random.Range(chestMinPos.x, chestMaxPos.x),
                Random.Range(chestMinPos.y, chestMaxPos.y)
            );

            GameObject chestObject = Instantiate(chest, new Vector3(chestPos.x, chestPos.y, -1f), Quaternion.identity);

            ChestItem chestItem = chestObject.GetComponent<ChestItem>();

            chestItem.Initialize(secondaryWeapons, chestUI);
        }
    }
}
