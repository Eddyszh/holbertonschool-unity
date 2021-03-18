using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

#pragma warning disable 0649

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource walkClip;
    [SerializeField] private AudioSource fallClip;

    [SerializeField] private AudioMixerSnapshot paused;
    [SerializeField] private AudioMixerSnapshot unpaused;

    [SerializeField] private AudioMixer mixer;
    public void PlayWalkingAudio()
    {
        if (walkClip.isPlaying == false)
            walkClip.Play();
    }

    public void PlayFallingAuido()
    {
        fallClip.PlayDelayed(.7f);
    }

    public void Paused()
    {
        if (Time.timeScale == 0)
            paused.TransitionTo(.01f);
        else
            unpaused.TransitionTo(.01f);
    }

    public void SetBgmVolume(float bgmVol)
    {
        mixer.SetFloat("bgmVolume", Mathf.Log10(bgmVol) * 20);
    }

    public void SetSfxVolume(float sfxVol)
    {
        mixer.SetFloat("sfxVolume", Mathf.Log10(sfxVol) * 20);
    }
}
