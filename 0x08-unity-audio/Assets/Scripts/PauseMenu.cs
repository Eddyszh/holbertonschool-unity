using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 0649

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 1f ? 0 : 1f;
        Cursor.visible = Cursor.visible == true ? false : true;
        audioManager.Paused();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause();
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
