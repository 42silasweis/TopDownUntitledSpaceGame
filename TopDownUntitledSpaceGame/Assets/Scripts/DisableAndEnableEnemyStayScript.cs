using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAndEnableEnemyStayScript : MonoBehaviour
{
    public float afterSpawnDelay = 0.8f;
    float startTimer;
    bool spawnedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<EnemyStaysNearPlayer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer > afterSpawnDelay && spawnedIn == false)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<EnemyStaysNearPlayer>().enabled = true;
            GetComponent<EnemyHealtyh2>().enabled = true;
            spawnedIn = true;
        }
    }
}
