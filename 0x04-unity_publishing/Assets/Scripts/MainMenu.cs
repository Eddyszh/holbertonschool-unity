using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Field to store the toggle ui object
    public Toggle colorblindMode;
    //Field to store goal's material object
    public Material goalMat;
    //Field to store trap's material object
    public Material trapMat;

    /// <summary>
    /// Loads the maze scene with the colorblind option on or off
    /// </summary>
    public void PlayMaze()
    {
        if (colorblindMode.isOn == true)
        {
            goalMat.color = Color.blue;
            trapMat.color = new Color32(255, 112, 0, 1);
        }
        else
        {
            goalMat.color = Color.green;
            trapMat.color = Color.red;
        }

        SceneManager.LoadScene("maze");
    }

    /// <summary>
    /// Quits the application
    /// </summary>
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
