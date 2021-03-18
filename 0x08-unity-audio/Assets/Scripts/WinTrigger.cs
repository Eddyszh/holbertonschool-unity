using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource winSting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            timer.StopTimer();
            timer.Win();
            canvas.SetActive(true);
            bgm.Stop();
            winSting.Play();
            Cursor.visible = true;
        }
    }
}
