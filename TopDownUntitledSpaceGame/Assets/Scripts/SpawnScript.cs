using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Variable to store the enemy prefab
    public GameObject enemy;

// Variable to know how fast we should create new enemies
    public float spawnTime = 2;

    void Start()
    {
        // Call the 'addEnemy' function in 0 second
        // Then every 'spawnTime' seconds
        InvokeRepeating("addEnemy", 0, spawnTime);
    }

    // New function to spawn an enemy
    void addEnemy()
    {
        // Get the renderer component of the spawn object
        rd = GetComponent<SpriteRenderer>();

        // Position of the left edge of the spawn object
        // It's: (position of the center) minus (half the width)
        x1 = transform.position.x - rd.bounds.size.x / 2;

        // Same for the right edge
        x2 = transform.position.x + rd.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        spawnPoint = Vector2(Random.Range(x1, x2), transform.position.y);

        // Create an enemy at the 'spawnPoint' position
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
