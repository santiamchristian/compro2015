using UnityEngine;
using System.Collections;

public class RoofTransparent : MonoBehaviour {

    public GameObject[] meshsToHide;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
    foreach(GameObject mesh in meshsToHide)
       if (other.gameObject.name == "Player" && mesh.renderer.enabled)
        {
            mesh.renderer.enabled = false; 
        }


    }

    void OnTriggerExit(Collider other)
    {
        foreach(GameObject mesh in meshsToHide)
        if (other.gameObject.name == "Player" && !mesh.renderer.enabled)
        {
            mesh.renderer.enabled = true;
        }
    }

   
}
