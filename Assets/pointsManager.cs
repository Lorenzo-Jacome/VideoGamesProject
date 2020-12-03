using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsManager : MonoBehaviour
{
    public Text playerPoints;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        points = PlayerPrefs.GetInt("PlayerPoints", 0);
        playerPoints.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoints(int pointsToAdd){
        points += pointsToAdd;
        PlayerPrefs.SetInt("PlayerPoints", points);
        playerPoints.text = points.ToString();

        if(points > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", points);
        }
    }
}
