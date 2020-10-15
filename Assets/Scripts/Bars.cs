/*
By: Lorenzo Jácome Ceniceros
Date: 01/10/2020
Description: Code that controls the sliders of the player when he uses any of his habilities or hp
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider healthBar;
    bool display = false;

    public void SetHealth(int health){
        healthBar.value = health;
    }
}
