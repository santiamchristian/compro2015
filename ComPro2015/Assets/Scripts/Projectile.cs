using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    public int speed;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        rigidbody.velocity = transform.InverseTransformDirection(Vector3.forward) * speed;
	}
}
