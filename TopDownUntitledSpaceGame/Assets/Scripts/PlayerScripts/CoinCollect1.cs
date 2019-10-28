using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollect1 : MonoBehaviour
{
    public int Coins = 0;
    int initialCoins = 0;
    public int neededCoins;
    public Text coinText;

    void Start()
    {
        coinText.text = "SCORE: " + Coins; // + "/" + neededCoins;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Points")
        {
            Coins += 10;
            coinText.text = "SCORE: " + Coins; // + "/" + neededCoins;
            Destroy(collision.gameObject);

            if(Coins >= neededCoins)
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
