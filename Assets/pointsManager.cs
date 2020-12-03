using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsManager : MonoBehaviour
{
    public Text playerPoints;
    static private int points;

    // Start is called before the first frame update
    void Start()
    {
        playerPoints.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoints(int pointsToAdd){
        points += pointsToAdd;
        playerPoints.text = points.ToString();
    }
}
