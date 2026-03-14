using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] elementsMeadow;
    public GameObject[] elementsDesert;
    public GameObject[] water;

    public int elementsNumber = 20000;
    public int waterNumber = 50;

    public Vector2 elementsMinPos = new Vector2(-209f, -151f);
    public Vector2 elementsMaxPos = new Vector2(233f, 142f);
    public Vector2 waterMinPos = new Vector2(-207f, -146f);
    public Vector2 waterMaxPos = new Vector2(229f, 139f);

    public GameSettingsManager settings;

    public LayerMask blockedLayers;
    public float checkRadius = 5f;
    public int spawnAttempts = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings = FindAnyObjectByType<GameSettingsManager>();

        ElementsSpawner();
        WaterSpawner();
    }

    public void WaterSpawner()
    {
        for(int i = 0; i < waterNumber; i++)
        {
            Vector2 waterPosition = Vector2.zero;
            bool validPosition = false;

            for(int j = 0; j < spawnAttempts; j++)
            {
                waterPosition = new Vector2(
                    UnityEngine.Random.Range(waterMinPos.x, waterMaxPos.x),
                    UnityEngine.Random.Range(waterMinPos.y, waterMaxPos.y)
                );

                if (!Physics2D.OverlapCircle(waterPosition, checkRadius, blockedLayers))
                {
                    validPosition = true;
                    break;
                }
            }

            if (validPosition)
            {
                int randomSpawn = UnityEngine.Random.Range(0, water.Length);
                GameObject chosenWater = water[randomSpawn];
                Instantiate(chosenWater, new Vector3(waterPosition.x, waterPosition.y, -1), Quaternion.identity);
            }
        }
    }

    public void ElementsSpawner()
    {
        for(int i = 0; i < elementsNumber; i++)
        {
            Vector2 elementPos = new Vector2(
                UnityEngine.Random.Range(elementsMinPos.x, elementsMaxPos.x),
                UnityEngine.Random.Range(elementsMinPos.y, elementsMaxPos.y)
            );

            if(settings.chosenMap.Contains("Forest"))
            {
                int randomSpawn = UnityEngine.Random.Range(0, elementsMeadow.Length);
                GameObject chosenElement = elementsMeadow[randomSpawn];
                Instantiate(chosenElement, new Vector3(elementPos.x, elementPos.y, -1), Quaternion.identity);
            } else
            {
                int randomSpawn = UnityEngine.Random.Range(0, elementsDesert.Length);
                GameObject chosenElement = elementsDesert[randomSpawn];
                Instantiate(chosenElement, new Vector3(elementPos.x, elementPos.y, -1), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
