using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;

    [Header("Spawn Area")]
    public float leftX = -2.5f;
    public float rightX = 2.5f;
    public float spawnY = 6f;

    [Header("Difficulty")]
    public float startSpawnTime = 1.5f;   // Easy at the beginning
    public float minSpawnTime = 0.3f;     // Fastest spawn rate
    public float difficultySpeed = 0.02f; // How quickly it gets harder

    private float currentSpawnTime;
    private float timer;

    void Start()
    {
        currentSpawnTime = startSpawnTime;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentSpawnTime)
        {
            SpawnMissile();
            timer = 0f;

            // Make the game harder over time
            currentSpawnTime -= difficultySpeed;

            // Don't go below the minimum spawn time
            if (currentSpawnTime < minSpawnTime)
            {
                currentSpawnTime = minSpawnTime;
            }
        }
    }

    void SpawnMissile()
    {
        float randomX = Random.Range(leftX, rightX);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0);

        Instantiate(missilePrefab, spawnPos, Quaternion.identity);
    }
}