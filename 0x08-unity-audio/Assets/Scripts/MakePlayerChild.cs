using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class MakePlayerChild : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject) player.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject) player.parent = null;
    }
}
