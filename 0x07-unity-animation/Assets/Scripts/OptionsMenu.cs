using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#pragma warning disable 0649

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    private int value;

    private void Awake()
    {
        toggle.isOn = PlayerPrefs.GetInt("isInverted") == 1 ? true : false;
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
        Time.timeScale = 1f;
    }

    public void Apply()
    {
        PlayerPrefs.Save();
        Back();
    }

    public void IsIverted()
    {
        value = toggle.GetComponent<Toggle>().isOn == true ? 1 : 0;
        PlayerPrefs.SetInt("isInverted", value);
        Debug.Log(value);
    }
}
