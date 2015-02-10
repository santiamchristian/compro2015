using UnityEngine;
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
        Fall();
        Move();

    }
    private void Fall()
    {
        if(! controller.isGrounded)
        velocity.y -= gravity;
    }
    private void Move()
    {   
        
        controller.Move(velocity* Time.deltaTime);
        
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            velocity.y = jumpSpeed;

        }

    }

    public void Direction(float x, float z)
    {
        velocity = new Vector3(x * speed, velocity.y, z * speed);
    }

}
