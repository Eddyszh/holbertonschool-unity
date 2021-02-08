using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraController : MonoBehaviour
{
    private float speed = 2f;
    private float mouseX, mouseY;

    [SerializeField] private Transform player;
    private Vector3 offset;

    ///<summary>
    /// Start is called before the first frame update
    ///</summary>
    void Start()
    {
        offset = transform.position - player.position;
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
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");
        Debug.Log(offset);
        if (offset.z > 0f)
            mouseY = Input.GetAxis("Mouse Y");
        Quaternion angleX = Quaternion.AngleAxis(mouseX * speed, Vector3.up);
        Quaternion angleY = Quaternion.AngleAxis(mouseY * speed, Vector3.right);
        offset.y = Mathf.Clamp(offset.y, 0f, 4f);
        offset = angleX * offset;
        offset = angleY * offset;
    }
}
