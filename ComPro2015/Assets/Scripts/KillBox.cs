using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	void Start ()
    {
	    
	}
	
	void Update () 
    {

	}

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().Kill();
    }
}
