/*
By: Lorenzo Jácome
Description: Manages everything related to the drops and their values
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyScript : MonoBehaviour
{
    public int amountRegen;
    public GameObject pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointsManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player" && gameObject.tag == "HealthDrop"){
            col.gameObject.GetComponent<Health>().HealthRegen(amountRegen);
            Destroy(gameObject);
        } else if (col.gameObject.tag == "Player" && gameObject.tag == "coinDrop"){
            pointManager.GetComponent<pointsManager>().addPoints(10);
            Destroy(gameObject);
        } else if(col.gameObject.tag == "Player" && gameObject.tag == "goldDrop"){
            pointManager.GetComponent<pointsManager>().addPoints(50);
            Destroy(gameObject);
        }
    }
}
