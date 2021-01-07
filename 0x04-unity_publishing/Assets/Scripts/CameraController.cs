using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public field to store player object
    public GameObject player;
    //pruvate field to store offset value
    private Vector3 offset;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        offset = new Vector3
            (
            transform.position.x - player.transform.position.x,
            transform.position.y - player.transform.position.y,
            transform.position.z - player.transform.position.z
            );
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        FollowPlayer();
    }

    /// <summary>
    /// Makes the camera follow the player
    /// </summary>
    private void FollowPlayer()
    {
        transform.position = player.transform.position + offset;
    }
}
