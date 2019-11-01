using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAndEnbaldeEnemyAIVersion : MonoBehaviour
{
    float afterSpawnDelay = 0.8f;
    float startTimer;
    bool spawnedIn = false;

    // Start is called before the first frame update
    void Start()
    {
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
            spawnedIn = true;
        }
    }
}
