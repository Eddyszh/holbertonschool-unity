using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 0649

public class PlayerController : MonoBehaviour
{
    private float gravity = 20f;
    private float jumpForce = 10f;
    private float speed = 6f;
    private Vector3 movement;
    private bool isFalling = false;

    CharacterController controller;
    public static bool isInputEnabled = true;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioManager audioManager;

    ///<summary>
    /// Start is called before the first frame update
    ///</summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isInputEnabled = true;
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
            {
                transform.GetChild(1).rotation = Quaternion.Slerp(
                    transform.GetChild(1).rotation,
                    Quaternion.LookRotation(movement),
                    Time.deltaTime * speed
                );
                audioManager.PlayWalkingAudio();
            }
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
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 20f, 0f);
            isFalling = true;
            anim.SetBool("isFalling", isFalling);
            audioManager.PlayFallingAuido();
        }
        else if (isFalling = true && controller.isGrounded)
        {
            isFalling = false;
            anim.SetBool("isFalling", isFalling);
        }
    }
}
