using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float maxTilt = 1f; // clamps extreme tilt values

    [Header("Death UI")]
    public GameObject deathUI; // Assign your Death Panel here in the Inspector
    public string enemyTag = "Enemy"; // Make sure your enemy GameObjects have this tag

    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (deathUI != null)
            deathUI.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isDead) return; // stop movement once dead

        float tiltX = Mathf.Clamp(Input.acceleration.x, -maxTilt, maxTilt);

        Vector2 movement = new Vector2(tiltX * speed, rb.linearVelocity.y);
        rb.linearVelocity = movement;
    }

    // If enemy has a normal (non-trigger) Collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Die();
        }
    }

    // If enemy has a Collider2D set to "Is Trigger"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // prevent multiple triggers
        isDead = true;

        rb.linearVelocity = Vector2.zero; // stop movement

        if (deathUI != null)
            deathUI.SetActive(true);

        Time.timeScale = 0f; // optional: pause the game
    }
}