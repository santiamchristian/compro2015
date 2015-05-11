using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform target; 

	// Use this for initialization
	void Start () {

        agent.SetDestination(target.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
