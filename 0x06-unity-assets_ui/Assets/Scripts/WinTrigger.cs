using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            timer.StopTimer();
            timer.Win();
            canvas.SetActive(true);
        }
    }
}
