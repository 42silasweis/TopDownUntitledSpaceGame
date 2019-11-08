using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStartDivertScene : MonoBehaviour
{
    public int Points = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Lvl1Score", Points);
        PlayerPrefs.SetInt("Lvl2Score", Points);
        PlayerPrefs.SetInt("Lvl3Score", Points);
        PlayerPrefs.SetInt("Lvl4Score", Points);
        PlayerPrefs.SetInt("Lvl2Complete", 0);
        PlayerPrefs.SetInt("Lvl3Complete", 0);
        PlayerPrefs.SetInt("Lvl4Complete", 0);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
