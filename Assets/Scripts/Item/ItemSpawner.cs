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

    public Vector2 chestMinPos = new Vector2(-200f, -144f);
    public Vector2 chestMaxPos = new Vector2(227f, 137f);

    public Vector2 itemMinPos = new Vector2(-205f, -149f);
    public Vector2 itemMaxPos = new Vector2(232f, 143f);

    public LayerMask waterLayer;
    public float checkRadius = 5f;
    public int spawnAttempts = 10;
    
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
            Vector2 foodPosition = Vector2.zero;
            bool validPosition = false;

            for(int j = 0; j < spawnAttempts; j++)
            {
                foodPosition = new Vector2(
                    Random.Range(itemMinPos.x, itemMaxPos.x),
                    Random.Range(itemMinPos.y, itemMaxPos.y)
                );

                if(!Physics2D.OverlapCircle(foodPosition, checkRadius, waterLayer))
                {
                    validPosition = true;
                    break;
                }
            }

            if (validPosition)
            {
                Instantiate(food, new Vector3(foodPosition.x, foodPosition.y, -1f), Quaternion.identity);
            }
        }
    }

    private void PotionSpawner()
    {
        for(int i = 0; i < potionNumber; i++)
        {
            Vector2 potionPosition = Vector2.zero;
            bool validPosition = false;

            for(int j = 0; j < spawnAttempts; j++)
            {
                potionPosition = new Vector2(
                    Random.Range(itemMinPos.x, itemMaxPos.x),
                    Random.Range(itemMinPos.y, itemMaxPos.y)
                );

                if(!Physics2D.OverlapCircle(potionPosition, checkRadius, waterLayer))
                {
                    validPosition = true;
                    break;
                }
            }

            if (validPosition)
            {
                Instantiate(potion, new Vector3(potionPosition.x, potionPosition.y, -1f), Quaternion.identity);
            }
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
            Vector2 chestPosition = Vector2.zero;
            bool validPosition = false;

            for(int j = 0; j < spawnAttempts; j++)
            {
                chestPosition = new Vector2(
                    Random.Range(chestMinPos.x, chestMaxPos.x),
                    Random.Range(chestMinPos.y, chestMaxPos.y)
                );

                if(!Physics2D.OverlapCircle(chestPosition, checkRadius, waterLayer))
                {
                    validPosition = true;
                    break;
                }
            }

            if (validPosition)
            {
                GameObject chestObject = Instantiate(chest, new Vector3(chestPosition.x, chestPosition.y, -1f), Quaternion.identity);

                ChestItem chestItem = chestObject.GetComponent<ChestItem>();

                chestItem.Initialize(secondaryWeapons, chestUI);
            }
        }
    }
}
