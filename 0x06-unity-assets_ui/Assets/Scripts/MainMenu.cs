using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("lastScene", 0);
        PlayerPrefs.Save();
    }
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
        if (level != 1)
            PlayerPrefs.SetInt("lastScene", level);
        PlayerPrefs.Save();
        Time.timeScale = 1f;
    }
}
