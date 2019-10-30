using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollect1 : MonoBehaviour
{
    public int Points = 0;
    int initialCoins = 0;
    public int neededPoints;
    public Text pointsText;
    public Text multiplierText;
    int pointMultuiplier;
    public int maxMultiplier = 100;

    void Start()
    {
        pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PointMulitplier")
        {
            pointMultuiplier++;
            if(pointMultuiplier >= maxMultiplier)
            {
                pointMultuiplier = maxMultiplier;
            }
            multiplierText.text = "MULTIPLIER: " + pointMultuiplier;
        }
        if (collision.gameObject.tag == "Points")
        {
            Points += 10;
            pointsText.text = "SCORE: " + Points; // + "/" + neededCoins;
            Destroy(collision.gameObject);

            if(Points >= neededPoints)
            {
                //SceneManager.LoadScene("Win");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
            void Update()
    {
        
    }
}
