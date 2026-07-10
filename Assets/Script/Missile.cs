using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destroy when it goes off screen
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}