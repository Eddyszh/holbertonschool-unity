using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        transform.Rotate(45f * Time.deltaTime, 0f, 0f);
    }
}
