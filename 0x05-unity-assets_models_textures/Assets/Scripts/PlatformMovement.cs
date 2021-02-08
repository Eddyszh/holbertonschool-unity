using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float min = 0f;
    private float max = 20f;
    public char axis;
    // Use this for initialization
    private void Start()
    {
        switch (axis)
        {
            case 'x':
                min = transform.position.x - 20;
                max = transform.position.x;
                break;
            case 'y':
                min = transform.position.y - 20;
                max = transform.position.y;
                break;
            case 'z':
                min = transform.position.z - 20;
                max = transform.position.z;
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        Movement(axis);
    }

    private void Movement(char axis)
    {
        switch (axis)
        {
            case 'x':
                transform.position = new Vector3(-Mathf.PingPong(Time.time * 5, max - min) + max, transform.position.y, transform.position.z);
                break;
            case 'y':
                transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 5, max - min) + max, transform.position.z);
                break;
            case 'z':
                transform.position = new Vector3(transform.position.x, transform.position.y, -Mathf.PingPong(Time.time * 5, max - min) + max);
                break;
        }
    }
}
