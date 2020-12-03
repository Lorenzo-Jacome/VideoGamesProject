using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    string displayText;
    public Text uiText;
    int setPoints;
    // Start is called before the first frame update
    void Start()
    {
        displayText = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        uiText.text = displayText;

        setPoints = 0;
        PlayerPrefs.SetInt("PlayerPoints", setPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
