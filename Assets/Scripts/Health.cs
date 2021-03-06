﻿
/*
By: Maximiliano Sapién
Colab: Lorenzo Jácome
Description: Manages the health of the player and enemies. It also only manages the player's stamina in relation to time. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider healthBar;
    bool display = false;
    public GameObject healthDrop, currency1, currency2;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("prefsHealth");
        if(healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
            display = true;
        }
    }
    void Update()
    {
        //HEALTH REGEN
        //healthBar.value = currentHealth;
    }

    //STAMINA COUNTER
    public void HealthRegen(int amount)
    {
        if(display && currentHealth < maxHealth)
        {
            currentHealth += amount;
            healthBar.value = currentHealth;
            PlayerPrefs.SetInt("prefsHealth", currentHealth);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(display)
        {
            healthBar.value = currentHealth;
            PlayerPrefs.SetInt("prefsHealth", currentHealth);
        }

        if(currentHealth <= 0)
        {
            if(this.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
            
            int randomDrop = Random.Range(1,100);
            
            if(randomDrop >= 96 && randomDrop <= 100)
            {
                Instantiate(healthDrop, this.gameObject.transform.position, Quaternion.identity);
            } 
            
            else if(randomDrop <= 70)
            {
                Instantiate(currency1, this.gameObject.transform.position, Quaternion.identity);
            } 
            
            else if(randomDrop >= 71 && randomDrop <= 95)
            {
                Instantiate(currency2, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
