using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex != 4)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (SceneManager.GetActiveScene().buildIndex == 4)
            SceneManager.LoadScene("MainMenu");

    }
}
