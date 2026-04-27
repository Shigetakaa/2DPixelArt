using System.Linq;
using UnityEngine;

public class ChestItem : MonoBehaviour
{
    public SecondaryWeaponsManager secondaryWeapons;
    public ChestUIManager chestUI;

    public AudioClip chestSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(SecondaryWeaponsManager weapons, ChestUIManager ui)
    {
        secondaryWeapons = weapons;
        chestUI = ui;

        chestUI.Initialize(secondaryWeapons);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(chestSound, transform, 1f);
            ChestUI();
            Destroy(gameObject);
        }
    }

    public void ChestUI()
    {
        var randomWeapons = secondaryWeapons.currentSecondaryWeapons
            .OrderBy(x => Random.value)
            .Take(3)
            .ToList();
        
        chestUI.ShowButtons(randomWeapons);
    }
}
