using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvoidsBullets : MonoBehaviour
{
    public GameObject target;
    public bool instant = false;
    public float speed = 3.0f;
    public float dist = 3;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (target == null)
        {
            FindTarget();
        }
        else
        {
            if (instant)
            {
                transform.position = target.transform.position;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else if(dist < 3)
            {
                transform.up = Vector3.Lerp(transform.up, target.transform.position - transform.position, 0.2f * timer);//0.053f);
                //float speed = GetComponent<Rigidbody2D>().velocity.magnitude;
                GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
            }
        }
    }
    void FindTarget()
    {
        dist = 10000;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("PBulletParent");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < dist)
            {
                target = enemies[i];
                dist = Vector3.Distance(transform.position, enemies[i].transform.position);
            }
        }
        if (dist > 5)
        {
            target = null;
        }
    }
}
