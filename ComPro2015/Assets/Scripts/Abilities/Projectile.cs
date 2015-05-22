using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int speed;
    public int shooterIndex;
    public bool wall;
    public int damage;
    public bool expires;
    public float duration = 30;
    public float distanceFromGround = 1f;
    public float dropSpeed;
    public Vector3 positionOffset;
    public float coolDown = 1;
    protected float elapsedTime;
    public bool continueAfterHit = false;
    public bool useGravity = false;


    // Use this for initialization
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        elapsedTime += Time.deltaTime;

        if (!useGravity)
        {
            rigidbody.velocity = transform.TransformDirection(Vector3.forward) * speed;
            Move();
        }
        if (expires && elapsedTime >= duration)
            Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!wall) { 
            Health health = other.GetComponent<Health>();
            if (health == null && other.tag != "Terrain")
                Destroy();
            else if (health.playerIndex != shooterIndex)
            {
                health.Damage(damage);
                if(!continueAfterHit)
                Destroy();
            }
        }
        else
        {
            if (other.tag == "Enemy")
            {
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.walled = gameObject;
            }
        }

    }
    void Move()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (hit.transform.tag == "Terrain")
                transform.position = new Vector3 (transform.position.x, transform.position.y - (hit.distance - distanceFromGround), transform.position.z);

    }
}
