using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class PlayerController : MonoBehaviour
{
    private float gravity = 20f;
    private float jumpForce = 10f;
    private float speed = 6f;
    private Vector3 movement;

    CharacterController controller;
    public static bool isInputEnabled = true;
    [SerializeField] private Animator anim;

    ///<summary>
    /// Start is called before the first frame update
    ///</summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
        Movement();
        ResetPosition();
    }

    ///<summary>
    /// Allows the player to move and jump
    ///</summary>
    private void Movement()
    {
        if (controller.isGrounded)
        {
            Vector3 dir = Vector3.zero;
            if (isInputEnabled)
            {
                dir.x = Input.GetAxis("Horizontal");
                dir.z = Input.GetAxis("Vertical");
            }
            Vector3 camDirection = Camera.main.transform.rotation * dir;
            movement = new Vector3(camDirection.x , 0, camDirection.z);
            movement *= speed;
            if (Input.GetButtonDown("Jump") && isInputEnabled)
                movement.y = jumpForce;
            if (dir != Vector3.zero)
                transform.GetChild(1).rotation = Quaternion.Slerp(
                    transform.GetChild(1).rotation,
                    Quaternion.LookRotation(movement),
                    Time.deltaTime * speed
                );
            anim.SetBool("isWalking", dir != Vector3.zero ? true : false);
        }
        anim.SetBool("isGrounded", controller.isGrounded);
        movement.y -= gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
    }

    /// <summary>
    /// Resets player position when falls
    /// </summary>
    private void ResetPosition()
    {
        anim.SetBool("isFalling", transform.position.y < -5f ? true : false);
        if (transform.position.y < -10f)
            transform.position = (new Vector3(0f, 10f, 0f));
    }
}
