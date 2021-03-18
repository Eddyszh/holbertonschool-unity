using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

#pragma warning disable 0649

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    private int value;

    private void Awake()
    {
        Cursor.visible = enabled;
        toggle.isOn = PlayerPrefs.GetInt("isInverted") == 1 ? true : false;
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
        Time.timeScale = 1f;
        audioManager.Paused();
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
    }

    public void SetBgmSlider()
    {
        PlayerPrefs.SetFloat("bgmVol", bgmSlider.value);
    }

    public void SetSfxSlider()
    {
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
    }
}
