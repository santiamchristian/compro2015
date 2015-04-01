using UnityEngine;
using System.Collections;

public class Tornado : Projectile {

    public float LaunchDistance = 10; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null)
            Destroy();

        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<MovementController>().Launch(LaunchDistance);
        }
        
    }

    void Suction()
    {

    }
}
