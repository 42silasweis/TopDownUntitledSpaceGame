using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBot : MonoBehaviour
{
    private Transform target;
    //private GameObject ttarget;
    public float chaseSpeed = 2.0f;
    public float chaseTriggerDistance = 5.0f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    // This is not nonsense code right?
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }

        Vector2 chaseDirection = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance)
        {
            Chase();
        }
    }
    void Chase() // Chase function
    {
        //home = false;
        Vector2 chaseDirection = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
}

