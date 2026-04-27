using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public float expAmount = 2f;

    private Transform target;
    private float speed = 0f;
    private bool isMoving = false;

    public AudioClip expSound;

    public void MoveTo(Transform player)
    {
        target = player;
        isMoving = true;
        speed = 5f;
    }

    void Update()
    {
        if (isMoving && target != null)
        {
            speed += 10f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    // Exp jest dodawany po interakcji z graczem
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Exp player = collision.gameObject.GetComponent<Exp>();

        if (player != null)
        {
            SoundManager.instance.PlaySound(expSound, transform, 1f);
            player.GetExp(expAmount);
            Destroy(gameObject);
        }
    }
}
