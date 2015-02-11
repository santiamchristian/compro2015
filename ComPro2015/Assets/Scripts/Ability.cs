using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {
    public Transform projectile;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Use()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
