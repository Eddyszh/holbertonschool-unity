using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
