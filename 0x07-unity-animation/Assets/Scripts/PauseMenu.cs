using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 0649

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1f)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
            Resume();
    }

    public void Pause()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("lastScene", 0);
        PlayerPrefs.Save();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
