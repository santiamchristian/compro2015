using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform[] targets;
    public GameObject walled;
    public Ability abilities;
    public int index;

    private int targetIndex; 

	// Use this for initialization
	void Start () {
        SetTarget(0);
        abilities = gameObject.GetComponentInChildren<Ability>();
	}
	
	// Update is called once per frame
    void Update()
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
        for (int i = 0; i < targets.Length; i++)
        {
            if(targets[i] != null && targetIndex == i){
                break;
            }
            else if (targets[i] != null && targetIndex != i)
            {
                SetTarget(i);
                break;
            }
        }
    }

    void SetTarget (int i)
    {
        agent.SetDestination(targets[i].transform.position);
        targetIndex = i;
    }

}
