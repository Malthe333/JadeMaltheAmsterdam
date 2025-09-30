using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CheckPoint1 : MonoBehaviour
{
    [HideInInspector] public int currentIndex = -1;     // highest checkpoint reached
    [HideInInspector] public Vector3 respawnPoint;      // where to respawn

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Start position is the fallback if no checkpoint reached yet
        respawnPoint = transform.position;
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = respawnPoint;
        // reset health/animation/state here if needed
    }

    // Example: auto-respawn if you fall off the map
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
            Respawn();

    }
}
