using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform target;
    public GameObject walled;
    public Ability abilities; 

	// Use this for initialization
	void Start () {
        SetTarget();
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
    }

    void SetTarget ()
    {
        agent.SetDestination(target.position);
    }

    public virtual void OnTriggerExit (Collider other)
    {

    }

}
