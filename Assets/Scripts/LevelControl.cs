
/*
By: Maximiliano Sapién
Description: Script that is called to manages scene
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public void GoToScene(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
}
