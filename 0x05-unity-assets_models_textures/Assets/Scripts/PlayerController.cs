using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class PlayerController : MonoBehaviour
{
    private float gravity = 20f;
    private float horizontal;
    private float jumpForce = 400f;
    private bool isJumping = false;
    private float speed = 10f;
    private float vertical;
    private Rigidbody rb;
    private Vector3 movement;

    ///<summary>
    /// Start is called before the first frame update
    ///</summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !isJumping) Jump();
        Movement();
    }

    ///<summary>
    /// Allows the player to move
    ///</summary>
    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical);
        movement = Camera.main.transform.TransformDirection(movement) * speed;
        movement.y = 0f;
        transform.Translate(movement * Time.deltaTime);
        rb.velocity -= new Vector3(0f, gravity * Time.deltaTime, 0f);
    }

    ///<summary>
    /// Allows the player to jump
    ///</summary>
    private void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        rb.velocity = Vector3.up * jumpForce * Time.deltaTime;
        isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject) isJumping = false;
    }
}
