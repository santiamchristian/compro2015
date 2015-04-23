﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int speed;
    public int shooterIndex;
    public int damage;
    public float duration = 30;
    public float distanceFromGround = 1f;
    public float dropSpeed;
    public Vector3 positionOffset;
    protected float elapsedTime;


    // Use this for initialization
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
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

    public virtual void OnTriggerEnter(Collider other)
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
                transform.position = new Vector3 (transform.position.x, transform.position.y - (hit.distance - distanceFromGround), transform.position.z);

    }
}