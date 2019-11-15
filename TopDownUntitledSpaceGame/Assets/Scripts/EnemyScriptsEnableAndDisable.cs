using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptsEnableAndDisable : MonoBehaviour
{
    public float afterSpawnDelay = 0.8f;
    float startTimer;
    bool spawnedIn = false;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //Makes the enemy face the player when spawned
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPosition = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.right = playerPosition;

        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SmartAIAvoidsBullets>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer > afterSpawnDelay && spawnedIn == false)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<SmartAIAvoidsBullets>().enabled = true;
            //GetComponent<EnemyHealth>().enabled = true;
            spawnedIn = true;
        }
    }
}
