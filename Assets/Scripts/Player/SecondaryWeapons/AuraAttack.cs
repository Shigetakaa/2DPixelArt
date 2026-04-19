using UnityEngine;

public class AuraAttack : MonoBehaviour
{
    public float lifeTime = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
