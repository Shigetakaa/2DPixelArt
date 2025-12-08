using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject chest;
    public GameObject potion;
    public GameObject food;

    public int chestNumber = 3;
    public int potionNumber = 20;
    public int foodNumber = 50;

    public SecondaryWeaponsManager secondaryWeapons;
    public ChestUIManager chestUI;

    public Vector2 chestMinPos = new Vector2(-7f, -7f);
    public Vector2 chestMaxPos = new Vector2(7f, 7f);

    public Vector2 itemMinPos = new Vector2(-207f, -141f);
    public Vector2 itemMaxPos = new Vector2(207f, 141f);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChestSpawner();
        PotionSpawner();
        FoodSpawner();
    }

    private void FoodSpawner()
    {
        for(int i = 0; i < foodNumber; i++)
        {
            Vector2 foodPos = new Vector2(
                Random.Range(itemMinPos.x, itemMaxPos.x),
                Random.Range(itemMinPos.y, itemMaxPos.y)
            );

            Instantiate(food, new Vector3(foodPos.x, foodPos.y, -1f), Quaternion.identity);
        }
    }

    private void PotionSpawner()
    {
        for(int i = 0; i < potionNumber; i++)
        {
            Vector2 potionPos = new Vector2(
                Random.Range(itemMinPos.x, itemMaxPos.x),
                Random.Range(itemMinPos.y, itemMaxPos.y)
            );

            Instantiate(potion, new Vector3(potionPos.x, potionPos.y, -1f), Quaternion.identity);
        }
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
