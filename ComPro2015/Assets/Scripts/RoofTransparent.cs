using UnityEngine;
using System.Collections;

public class RoofTransparent : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
  
       if (other.gameObject.name == "Player" && renderer.enabled)
        {
            renderer.enabled = false; 
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" && !renderer.enabled)
        {
            renderer.enabled = true;
        }
    }

}
