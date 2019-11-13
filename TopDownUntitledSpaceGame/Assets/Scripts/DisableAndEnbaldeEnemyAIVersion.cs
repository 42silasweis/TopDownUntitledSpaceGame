using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAndEnbaldeEnemyAIVersion : MonoBehaviour
{
    public float afterSpawnDelay = 0.8f;
    float startTimer;
    bool spawnedIn = false;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //This makes the enemy face towards the player when they spawn
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPosition = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.right = playerPosition;

        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Enemy1AI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer > afterSpawnDelay && spawnedIn == false)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<Enemy1AI>().enabled = true;
            GetComponent<EnemyHealth>().enabled = true;
            spawnedIn = true;
        }
    }
}
