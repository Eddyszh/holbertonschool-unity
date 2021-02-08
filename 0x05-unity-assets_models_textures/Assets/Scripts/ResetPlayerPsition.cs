using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPsition : MonoBehaviour
{
    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
        ResetPosition();
    }

    ///<summary>
    /// Resets the position at the start of the game
    ///</summary>
    private void ResetPosition()
    {
        if (transform.position.y < -5)
            transform.position = new Vector3(0f, 5f, 0f);
    }
}
