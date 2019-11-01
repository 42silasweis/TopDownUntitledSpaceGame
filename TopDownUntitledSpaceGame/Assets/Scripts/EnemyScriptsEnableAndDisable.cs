using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptsEnableAndDisable : MonoBehaviour
{
    float afterSpawnDelay = 0.8f;
    float startTimer;
    bool spawnedIn = false;

    // Start is called before the first frame update
    void Start()
    {
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
            spawnedIn = true;
        }
    }
}
