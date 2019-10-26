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
            Blink();
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


    void Blink()
    {
        if (timer >= destroyPoints * 0.5f)
        {
            if (timer >= destroyPoints * 0.525f)
            {
                if (timer >= destroyPoints * 0.575f)
                {
                    if (timer >= destroyPoints * 0.6f)
                    {
                        if (timer >= destroyPoints * 0.625f)
                        {
                            if (timer >= destroyPoints * 0.65f)
                            {
                                if (timer >= destroyPoints * 0.675f)
                                {
                                    if (timer >= destroyPoints * 0.7f)
                                    {
                                        if (timer >= destroyPoints * 0.725f)
                                        {
                                            if (timer >= destroyPoints * 0.75f)
                                            {
                                                if (timer >= destroyPoints * 0.775f)
                                                {
                                                    if (timer >= destroyPoints * 0.8f)
                                                    {
                                                        if (timer >= destroyPoints * 0.825f)
                                                        {
                                                            if (timer >= destroyPoints * 0.84f)
                                                            {
                                                                if (timer >= destroyPoints * 0.85f)
                                                                {
                                                                    if (timer >= destroyPoints * 0.86f)
                                                                    {
                                                                        if (timer >= destroyPoints * 0.87f)
                                                                        {
                                                                            if (timer >= destroyPoints * 0.88f)
                                                                            {
                                                                                if (timer >= destroyPoints * 0.89f)
                                                                                {
                                                                                    if (timer >= destroyPoints * 0.9f)
                                                                                    {
                                                                                        if (timer >= destroyPoints * 0.91f)
                                                                                        {
                                                                                            if (timer >= destroyPoints * 0.92f)
                                                                                            {
                                                                                                if (timer >= destroyPoints * 0.93f)
                                                                                                {
                                                                                                    if (timer >= destroyPoints * 0.94f)
                                                                                                    {
                                                                                                        if (timer >= destroyPoints * 0.95f)
                                                                                                        {
                                                                                                            if (timer >= destroyPoints * 0.96f)
                                                                                                            {
                                                                                                                if (timer >= destroyPoints * 0.97f)
                                                                                                                {
                                                                                                                    if (timer >= destroyPoints * 0.98f)
                                                                                                                    {
                                                                                                                        if (timer >= destroyPoints * 0.99f)
                                                                                                                        {
                                                                                                                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                                                                            return;
                                                                                                                        }
                                                                                                                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                                                                        return;
                                                                                                                    }
                                                                                                                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                                                                    return;
                                                                                                                }
                                                                                                                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                                                                return;
                                                                                                            }
                                                                                                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                                                            return;
                                                                                                        }
                                                                                                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                                                        return;
                                                                                                    }
                                                                                                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                                                    return;
                                                                                                }
                                                                                                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                                                return;
                                                                                            }
                                                                                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                                            return;
                                                                                        }
                                                                                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                                        return;
                                                                                    }
                                                                                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                                    return;
                                                                                }
                                                                                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                                return;
                                                                            }
                                                                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                            return;
                                                                        }
                                                                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                                        return;
                                                                    }
                                                                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                    return;
                                                                }
                                                                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                                return;
                                                            }
                                                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                            return;
                                                        }
                                                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                        return;
                                                    }
                                                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                                    return;
                                                }
                                                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                                return;
                                            }
                                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                            return;
                                        }
                                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                        return;
                                    }
                                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                                    return;
                                }
                                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                return;
                            }
                            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                            return;
                        }
                        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                        return;
                    }
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                    return;
                }
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                return;
            }
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            return;
        }
    }
}
