using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraController : MonoBehaviour
{
    private float speed = 2f;
    private float mouseX, mouseY;
    private Quaternion camRotation;

    [SerializeField] private Transform player;
    private Vector3 offset;

    ///<summary>
    /// Start is called before the first frame update
    ///</summary>
    void Start()
    {
        offset = transform.position - player.position;
        camRotation = transform.rotation;
    }

    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
        FollowPlayer();
        if (Input.GetMouseButton(0))
            Rotation();
    }

    ///<summary>
    /// Makes the camera follow the player
    ///</summary>
    private void FollowPlayer()
    {
        transform.position = player.position + offset;
        transform.LookAt(player);
    }

    ///<summary>
    /// Orbits the camera aorund the player
    ///</summary>
    private void Rotation()
    {
        mouseX += Input.GetAxis("Mouse X") * speed;
        camRotation.y -= Input.GetAxis("Mouse Y") * speed;
        camRotation.y = Mathf.Clamp(camRotation.y, 0f, 75f);
        transform.LookAt(player);
        transform.rotation = Quaternion.Euler(camRotation.y, mouseX, 0f);
        transform.position = player.position + offset;
    }
}
