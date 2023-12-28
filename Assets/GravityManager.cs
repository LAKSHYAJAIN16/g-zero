using System;
using UnityEngine;
using TMPro;

public class GravityManager : MonoBehaviour
{
    // Constant Array of Directions
    public readonly string[] DIRECTIONS = { "←", "↑", "→", "↓" };

    // The Current Direction the gravity is in
    public int curDirection = 3;

    // Grace Period when starting
    public float gracePeriod = 10f;

    // The Time between changes
    public float changeTime = 10f;

    // Gravity
    public float Gravity = 30f;

    // PlayerMovement
    public PlayerMovement playerMovement;
    public MoveCamera playerCamera;

    //Text at the top
    public TextMeshProUGUI Text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeGravityDirection();
        }
    }

    private void ChangeGravityDirection()
    {
        // Get the target direction. Take the current index and increment it by one if we're not at the bound
        curDirection = (curDirection + 1) % 4;
        Text.text = DIRECTIONS[curDirection];

        // Update Gravity
        playerMovement.time = 0f;
        if(curDirection == 0)
        {
            // Gravity in the left direction
            Physics.gravity = new Vector3(-Gravity, 0f);
            playerMovement.targetZRot = -90f;
        }
        else if(curDirection == 2)
        {
            // Gravity in the right direction
            Physics.gravity = new Vector3(Gravity, 0f, 0f);
            playerMovement.targetZRot = 90f;
        }
        else if(curDirection == 1)
        {
            // Gravity in the top direction
            Physics.gravity = new Vector3(0f, Gravity, 0f);
            playerMovement.targetZRot = 180f;
        }
        else if(curDirection == 3)
        {
            // Gravity in the bottom direction
            Physics.gravity = new Vector3(0f, -Gravity, 0f);
            playerMovement.targetZRot = 0f;
        }
    }
}