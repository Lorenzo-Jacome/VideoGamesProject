
/*
By: Maximiliano Sapién
Description: To spawn or despawn any UI element when its functions are called
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItoggler : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    public void BringElement(string name)
    {
        Instantiate(canvas, transform.position, Quaternion.identity);
    }

    public void DestroyElement(string name)
    {
        Destroy(gameObject);
    }

    public void ResetHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
