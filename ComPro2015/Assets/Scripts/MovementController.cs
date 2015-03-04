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
    public float rotationSpeed = 20f;

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

    public void Direction(Vector2 direction)
    {
        velocity = new Vector3(direction.x * speed, velocity.y, direction.y * speed);
    }

    public void Rotate(Vector2 rotation)
    {
        if (rotation.x != 0 || rotation.y != 0)
        {
            Quaternion targetRotation = Quaternion.Euler(0.0f, Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void RotateTowardsCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation =  Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, targetRotation.y, 0, targetRotation.w), speed * Time.deltaTime); // WITH SPEED
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1); // WITHOUT SPEED!!!
        }
            

    }
}
