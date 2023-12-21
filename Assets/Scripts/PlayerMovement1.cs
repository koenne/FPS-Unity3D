﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;
    private bool menu = false;
    public GameObject menuObject;

    Vector3 velocity;
    bool isGrounded;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu = !menu;
        }
        if (!menu)
        {
            menuObject.SetActive(false);
            //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetKey("left shift"))
            {
                speed = 10;
            }
            else
            {
                speed = 5;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            menuObject.SetActive(true);
        }
    }
}