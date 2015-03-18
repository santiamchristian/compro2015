using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int speed;
    public int shooterIndex;
    public int damage;
    public float duration = 30;
    public float distanceFromGround = 1f;
    public float dropSpeed;
    private float elapsedTime;


    // Use this for initialization
    void Start()
    {
        distanceFromGround = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        rigidbody.velocity = transform.TransformDirection(Vector3.forward) * speed;
        Move();
        if (elapsedTime >= duration)
            Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null)
            Destroy();
        else if (health.playerIndex != shooterIndex)
        {
            health.Damage(damage);
            Destroy();
        }

    }
    void Move()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (hit.transform.tag == "Terrain")
                transform.position =Vector3.Slerp(transform.position, new Vector3 (transform.position.x, transform.position.y - (hit.distance - distanceFromGround), transform.position.z), dropSpeed);

    }
}
