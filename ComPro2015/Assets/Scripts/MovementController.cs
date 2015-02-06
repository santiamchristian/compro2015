﻿using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private CharacterController controller;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    public void Move(Vector3 moveDirection)
    {   if (controller.isGrounded)
        {
            this.moveDirection = moveDirection;
        }
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = jumpSpeed;

        }

    }
}
