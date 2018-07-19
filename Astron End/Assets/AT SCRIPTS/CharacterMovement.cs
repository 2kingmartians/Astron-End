using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float cruisingSpeed;
    bool isSprintng;

    float speed = 6.0F;
    float sprintSpeed = 8.0f;
    float jumpSpeed = 8.0F;
    float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    PlayerStats playerStats;

    private void Start()
    {
        playerStats = PlayerStats.instance;
        cruisingSpeed = speed;
    }

    void Update()
    {
        speed = playerStats.speed;
        sprintSpeed = playerStats.sprintSpeed;
        jumpSpeed = playerStats.jumpSpeed;
        gravity = playerStats.jumpGravity;

        if (Input.GetButtonDown("Sprint"))
        {
            cruisingSpeed = sprintSpeed;
            isSprintng = true;
        }
        else if(Input.GetButtonUp("Sprint"))
        {
            cruisingSpeed = speed;
            isSprintng = false;
        }

        playerStats.isSprinting = isSprintng;

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= cruisingSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}