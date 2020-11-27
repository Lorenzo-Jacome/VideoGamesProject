using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseScreen;

    public static bool GamePaused = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                ResumeGame();
            }else
            {
                PauseGame();
            }
            
        
        }
    }

    public void PauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
}
