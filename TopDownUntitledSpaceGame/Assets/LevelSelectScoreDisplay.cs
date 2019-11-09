using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScoreDisplay : MonoBehaviour
{
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    int IsLevel2Unlocked;
    int IsLevel3Unlocked;
    int IsLevel4Unlocked;

    bool isUnlocked2 = false;
    bool isUnlocked3 = false;
    bool isUnlocked4 = false;

    public Text level1PointsText;
    public Text level2PointsText;
    public Text level3PointsText;
    public Text level4PointsText;

    int prefPoints1;
    int prefPoints2;
    int prefPoints3;
    int prefPoints4;

    string prefPointsLevel1;
    string prefPointsLevel2;
    string prefPointsLevel3;
    string prefPointsLevel4;
    // Start is called before the first frame update
    void Start()
    {
        IsLevel2Unlocked = PlayerPrefs.GetInt("Lvl1Complete");
        IsLevel3Unlocked = PlayerPrefs.GetInt("Lvl2Complete");
        IsLevel4Unlocked = PlayerPrefs.GetInt("Lvl3Complete");

        Debug.Log(IsLevel2Unlocked);
        Debug.Log(IsLevel3Unlocked);
        Debug.Log(IsLevel4Unlocked);

        Level2.GetComponent<Button>().interactable = false;
        Level3.GetComponent<Button>().interactable = false;
        Level4.GetComponent<Button>().interactable = false;

        prefPoints1 = PlayerPrefs.GetInt("Lvl1Score");
        prefPoints2 = PlayerPrefs.GetInt("Lvl2Score");
        prefPoints3 = PlayerPrefs.GetInt("Lvl3Score");
        prefPoints4 = PlayerPrefs.GetInt("Lvl4Score");

        prefPointsLevel1 = prefPoints1.ToString("#,##0");
        prefPointsLevel2 = prefPoints2.ToString("#,##0");
        prefPointsLevel3 = prefPoints3.ToString("#,##0");
        prefPointsLevel4 = prefPoints4.ToString("#,##0");

        level1PointsText.text = "" + prefPointsLevel1;
        level2PointsText.text = "" + prefPointsLevel2;
        level3PointsText.text = "" + prefPointsLevel3;
        level4PointsText.text = "" + prefPointsLevel4;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLevel2Unlocked == 1 && isUnlocked2 == false)
        {
            isUnlocked2 = true;
            Level2.GetComponent<Button>().interactable = true;
        }
        if (IsLevel3Unlocked == 1 && isUnlocked3 == false)
        {
            isUnlocked2 = true;
            Level3.GetComponent<Button>().interactable = true;
        }
        if (IsLevel4Unlocked == 1 && isUnlocked4 == false)
        {
            isUnlocked2 = true;
            Level4.GetComponent<Button>().interactable = true;
        }



        /*
        prefPointsLevel1 = prefPoints1.ToString("#,##0");
        prefPointsLevel2 = prefPoints2.ToString("#,##0");
        prefPointsLevel3 = prefPoints3.ToString("#,##0");
        prefPointsLevel4 = prefPoints4.ToString("#,##0");
        */
    }
}
