using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Transform player;
    private bool magnetActive = false;

    public float speed = 15f;

    public void StartMagnet(Transform target)
    {
        player = target;
        magnetActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(magnetActive && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
