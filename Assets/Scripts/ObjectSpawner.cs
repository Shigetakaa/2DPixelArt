using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] elementsMeadow;
    public GameObject[] elementsDesert;

    public int elementsNumber = 200;

    public Vector2 elementsMinPos = new Vector2(-209f, -151f);
    public Vector2 elementsMaxPos = new Vector2(233f, 142f);

    public GameSettingsManager settings;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings = FindAnyObjectByType<GameSettingsManager>();

        ElementsSpawner();
    }

    private void ElementsSpawner()
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
