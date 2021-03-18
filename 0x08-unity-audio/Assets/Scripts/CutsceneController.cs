using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Canvas timerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.Paused();
        StartCoroutine(CutsceneAnim());
    }

    IEnumerator CutsceneAnim()
    {
        yield return new WaitForSeconds(3f);
        controller.enabled = true;
        mainCamera.SetActive(true);
        timerCanvas.enabled = true;
        gameObject.SetActive(false);
    }
}
