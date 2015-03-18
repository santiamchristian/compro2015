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
        base.OnTriggerEnter(other);
        if (other.gameObject.name == "Player")
        {

            other.gameObject.GetComponent<MovementController>().Launch(10);
        }
    }

    void Suction()
    {

    }
}
