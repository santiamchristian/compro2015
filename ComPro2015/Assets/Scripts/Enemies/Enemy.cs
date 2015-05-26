using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform[] targets;
    public GameObject walled;
    public Ability abilities;
    public int index;

    private bool targetSet;
    private int targetIndex; 

	// Use this for initialization
	void Start () {
        abilities = gameObject.GetComponentInChildren<Ability>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (targetSet)
        {
            if (walled == null)
            {
                agent.Resume();
            }
            else
                agent.Stop();

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {

                    abilities.Use(0);

                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        // Done
                    }
                }
            }
        }
        if (targets[targetIndex] != null)
        {
            SetTarget(targetIndex % (targets.Length - 1));
        }
    }

    void SetTarget (int i)
    {
        if (targets != null)
        {
            agent.SetDestination(targets[i].transform.position);
            targetIndex = i;
            targetSet = true; 
        }
    }

}
