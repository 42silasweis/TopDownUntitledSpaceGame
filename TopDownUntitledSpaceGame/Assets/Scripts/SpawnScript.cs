using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject enemy;
    //public float spawnDistance = 3.0f;
    public Vector3 spawnPosition;

    float time;
    float time2;
    public float spawnTime = 10;
    public float spawnTimeFrame = 30.0f;
    public float spawnDelay = 0.6f;
    public float spawnRange = 1.5f;
    public float LevelClock;

    float spawnDistanceX;
    float spawnDistanceY;
    float spawnDistanceX2;
    float spawnDistanceY2;
    void Start()
    {
        //Turns the the spawners transform position and makes a value that is 
        //minuss the spawnRange into a float that can be used in the new Vector2 later
        spawnDistanceX = transform.position.x;
        spawnDistanceY = transform.position.y;
        spawnDistanceX2 = transform.position.x - spawnRange;
        spawnDistanceY2 = transform.position.y - spawnRange;

        //spawnPosition = new Vector2(Random.Range(-spawnDistanceX, spawnDistanceX), Random.Range(-spawnDistanceY, spawnDistanceY));
        //spawnPosition.Normalize();
    }
    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;
        //spawnTimeFrame += Time.deltaTime;
        LevelClock += Time.deltaTime;

        if (time < spawnTime && time2 > spawnDelay)
        {
            time2 = 0;
            spawnPosition = new Vector3(Random.Range(spawnDistanceX2, spawnDistanceX), Random.Range(spawnDistanceY2, spawnDistanceY));
            //spawnPosition.Normalize();
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            Debug.Log(spawnPosition);
        }
        //Debug.Log(time);
        //Debug.Log(time2);
    }

}
