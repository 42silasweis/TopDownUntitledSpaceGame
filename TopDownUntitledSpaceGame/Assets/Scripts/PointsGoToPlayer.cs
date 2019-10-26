using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGoToPlayer : MonoBehaviour
{
    public float timer = 0;
    public float destroyPoints = 3.0f;

    private Transform player;
    public float chaseSpeed = 2.0f;
    public float chaseTriggerDistance = 5.0f;
    public bool willDespawn = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // This is not nonsense code right?
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance)
        {
            Chase();
        }
        else
        {
            willDespawn = true;
        }
        //Timer will make points despawn after the time set in destroyPoints passes
        timer += Time.deltaTime;
        if (timer >= destroyPoints && willDespawn == true)
        {
            Destroy(gameObject);
        }
    }

    void Chase() // Chase function
    {
        willDespawn = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}
