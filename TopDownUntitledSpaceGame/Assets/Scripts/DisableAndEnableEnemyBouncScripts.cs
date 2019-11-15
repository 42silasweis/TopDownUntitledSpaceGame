using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAndEnableEnemyBouncScripts : MonoBehaviour
{
    public float afterSpawnDelay = 0.8f;
    float startTimer;
    bool spawnedIn = false;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPosition = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.right = playerPosition;
        //GetComponent<PolygonCollider2D>().enabled = false;
        //GetComponent<BounceScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer > afterSpawnDelay && spawnedIn == false)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<BounceScript>().enabled = true;
            //GetComponent<EnemyHealth>().enabled = true;
            spawnedIn = true;
        }
    }
}
