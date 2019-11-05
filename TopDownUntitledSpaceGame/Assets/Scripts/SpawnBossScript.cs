using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossScript : MonoBehaviour
{
    public int pointsPlayerNeeds;
    int currentPoints;
    public GameObject enemy;
    public Vector3 spawnPosition;
    float time;
    public float timeTillStart = 30.0f;
    public float spawnRangeY = 1.5f;
    public float spawnRangeX = 1.5f;
    int enemyCount = 0;
    int wave = 0;
    public int maxWaves = 6;
    public float waveDelay = 5;
    public int maxEnemies = 5;
    int inititalMaxEnemies;
    bool spawned = false;

    Transform player;
    Vector3 playerPosition;
    public float playerTooClose = 0.8f;

    float spawnDistanceX;
    float spawnDistanceY;
    float spawnDistanceX2;
    float spawnDistanceY2;
    void Start()
    {
        /*Turns the the spawners transform position and makes a value that is 
        minus the spawnRange into a float that can be used in the new Vector2 later */
        spawnDistanceX = transform.position.x;
        spawnDistanceY = transform.position.y;
        spawnDistanceX2 = transform.position.x - spawnRangeX;
        spawnDistanceY2 = transform.position.y - spawnRangeY;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPosition = new Vector3(Random.Range(spawnDistanceX2, spawnDistanceX), Random.Range(spawnDistanceY2, spawnDistanceY));
        inititalMaxEnemies = maxEnemies;
    }
    void Update()
    {
        currentPoints = player.GetComponentInChildren<CoinCollect1>().Points;

        time += Time.deltaTime;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        //Checks the distance between the player and the current random spawnpoint
        Vector3 playerPosition = (player.position - spawnPosition);
        //Vector2 playerDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

        if (currentPoints > pointsPlayerNeeds && enemyCount < maxEnemies && wave < maxWaves && time > timeTillStart && spawned == false)
        {
            //If the player to too close to the last randomly set spawnpoint it will keep getting a new random position until it can spawn
            if (playerPosition.magnitude > playerTooClose)
            {
                spawned = true;
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                RandoomPosition();
            }
            else
            {
                RandoomPosition();
            }
        }
    }

    void RandoomPosition() //Randomly selects a range itn which to spawn the next Enemy
    {
        spawnPosition = new Vector3(Random.Range(spawnDistanceX2, spawnDistanceX), Random.Range(spawnDistanceY2, spawnDistanceY));
    }
}
