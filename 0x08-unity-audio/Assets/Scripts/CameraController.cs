using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraController : MonoBehaviour
{
    private float speed = 2f;
    private float mouseX, mouseY;

    public bool isInverted;

    [SerializeField] private Transform player;
    private Vector3 offset;
    private Quaternion camRotation;

    ///<summary>
    /// Start is called before the first frame update
    ///</summary>
    void Start()
    {
        Cursor.visible = false;
        transform.SetParent(player.GetChild(0));
        transform.localPosition = new Vector3(0, 2.5f, -6.25f);
        transform.localRotation = Quaternion.Euler(9f, 0, 0);
        offset = transform.localPosition - player.GetChild(0).position;
        camRotation = transform.localRotation;
    }

    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void LateUpdate()
    {
        if (Input.GetMouseButton(1) && Time.timeScale == 1f)
        {
            FollowPlayer();
            Rotation();
        }
    }

    ///<summary>
    /// Makes the camera follow the player
    ///</summary>
    private void FollowPlayer()
    {
        transform.localPosition = player.GetChild(0).localPosition + offset;
        transform.LookAt(player.GetChild(0));
    }

    ///<summary>
    /// Orbits the camera aorund the player
    ///</summary>
    private void Rotation()
    {
        isInverted = PlayerPrefs.GetInt("isInverted") == 1 ? true : false;
        if (isInverted == true)
            mouseY = -Input.GetAxis("Mouse Y") * speed;
        else
            mouseY = Input.GetAxis("Mouse Y") * speed;
        mouseX = Input.GetAxis("Mouse X") * speed;
        camRotation.x += mouseX;
        camRotation.y += mouseY;
        transform.localRotation = Quaternion.Euler(camRotation.y, camRotation.x, camRotation.z);
        camRotation.y = Mathf.Clamp(camRotation.y, 0.0f, 80.0f);
        transform.localPosition = transform.localRotation * offset;
    }
}
