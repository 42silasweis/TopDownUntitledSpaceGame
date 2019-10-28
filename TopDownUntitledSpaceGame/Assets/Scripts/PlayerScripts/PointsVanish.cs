using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsVanish : MonoBehaviour
{
    float timer = 0;
    public float destroyPoints = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destroyPoints)
        {
            Destroy(gameObject);
        }
    }
}
