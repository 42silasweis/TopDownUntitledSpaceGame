using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int Lives = 3;
    int Points;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Lives", Lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ContinuePlaying() //For the Win scene
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void ResetAndContinue() //This is for the Win Scene
    {
        PlayerPrefs.SetInt("Lvl1Score", Points);
        PlayerPrefs.SetInt("Lvl2Score", Points);
        PlayerPrefs.SetInt("Lvl3Score", Points);
        PlayerPrefs.SetInt("Lvl4Score", Points);

        PlayerPrefs.SetInt("Lvl1Complete", 0);
        PlayerPrefs.SetInt("Lvl2Complete", 0);
        PlayerPrefs.SetInt("Lvl3Complete", 0);
        PlayerPrefs.SetInt("Lvl4Complete", 0);

        SceneManager.LoadScene("MainMenu");
    }
    public void ResetScores() //For Title Screen
    {
        PlayerPrefs.SetInt("Lvl1Score", Points);
        PlayerPrefs.SetInt("Lvl2Score", Points);
        PlayerPrefs.SetInt("Lvl3Score", Points);
        PlayerPrefs.SetInt("Lvl4Score", Points);

        PlayerPrefs.SetInt("Lvl1Complete", 0);
        PlayerPrefs.SetInt("Lvl2Complete", 0);
        PlayerPrefs.SetInt("Lvl3Complete", 0);
        PlayerPrefs.SetInt("Lvl4Complete", 0);
    }
    public void LoadLevel1() //For Level Select LoadLevel1-LoadLevel4
    {
        SceneManager.LoadScene("Level1");
        
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect"); // For Title Screen AKA MainMenu
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");//To go back to Main Menu from Level Select
    }
    public void QuitGame()//For Title Screen AKA MainMenu
    {
        Application.Quit();
    }
}
