using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class TimerTrigger : MonoBehaviour
{
    [SerializeField] private Timer time;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject) time.enabled = true;
    }
}
