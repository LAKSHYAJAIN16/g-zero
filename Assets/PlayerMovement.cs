using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Assingables
    public Transform playerCam;
    public Transform orientation;

    //Other
    private Rigidbody rb;

    //Movement
    public float moveSpeed = 4500;
    public bool grounded;
    public LayerMask whatIsGround;

    //Jumping
    private bool readyToJump = true;
    private float jumpCooldown = 0.25f;
    public float jumpForce = 550f;

    //Input
    float x, y;
    bool jumping;

    //Rotation from GravityManager
    public float targetZRot = 0f;
    public float rotSpeed = 10f;
    public float time = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        MyInput();
        Look();
        time += Time.deltaTime * 1/ rotSpeed;
    }

    private void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButton("Jump");
    }

    private void Movement()
    {
        //If holding jump && ready to jump, then jump
        if (readyToJump && jumping) Jump();

        //Apply forces to move player
        //rb.AddForce(playerCam.transform.forward * moveSpeed * Time.deltaTime, ForceMode.Force);
        //rb.AddForce(playerCam.transform.right * x * moveSpeed * Time.deltaTime, ForceMode.Force);
    }

    private void Jump()
    {
        if (grounded && readyToJump)
        {
            readyToJump = false;

            //Add jump forces
            rb.AddForce(playerCam.up * jumpForce * 1.5f);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private float desiredX;
    private void Look()
    {
        //Perform the rotations
        playerCam.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(0f, 0f, playerCam.transform.localRotation.eulerAngles.z), Quaternion.Euler(0f, 0f, targetZRot), time);
        orientation.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(0, 0f, playerCam.transform.localRotation.eulerAngles.z), Quaternion.Euler(0, 0f, targetZRot), time);
    }

    /// <summary>
    /// Handle ground detection
    /// </summary>
    private void OnCollisionStay(Collision other)
    {
        //Make sure we are only checking for walkable layers
        int layer = other.gameObject.layer;
        if (whatIsGround != (whatIsGround | (1 << layer))) return;

        //Iterate through every collision in a physics update
        grounded = true;
    }

    /// <summary>
    /// Collision
    /// </summary>
    private void OnCollisionExit(Collision other)
    {
        //Make sure we are only checking for walkable layers
        int layer = other.gameObject.layer;
        if (whatIsGround != (whatIsGround | (1 << layer))) return;

        //Iterate through every collision in a physics update
        grounded = false;
    }
}