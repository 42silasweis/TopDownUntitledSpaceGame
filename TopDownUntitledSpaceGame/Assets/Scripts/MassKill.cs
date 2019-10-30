using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassKill : MonoBehaviour
{
    public bool killAll = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MassKillEnemies" && killAll == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTrigger2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MassKillEnemies" && killAll == true)
        {
            Destroy(gameObject);
        }
    }
}
