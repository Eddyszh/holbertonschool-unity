using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private Timer timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            timer.StopTimer();
        }
    }
}
