using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform target;
    public GameObject walled;

	// Use this for initialization
	void Start () {
        SetTarget();
	}
	
	// Update is called once per frame
	void Update () {
        if (walled == null)
        {
            agent.enabled = true;
            SetTarget();
        }
        else
            agent.enabled = false;
	}

    void SetTarget ()
    {
        agent.SetDestination(target.position);
    }

    public virtual void OnTriggerExit (Collider other)
    {

    }

}
