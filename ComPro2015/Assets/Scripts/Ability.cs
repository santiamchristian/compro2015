using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {
    public Transform projectile;
    private int playerIndex;
    private GameObject projectiles;

	// Use this for initialization
    void Start()
    {
        playerIndex = transform.parent.GetComponent<Player>().playerIndex;
        projectiles = GameObject.Find("Projectiles");
    }
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Use()
    {
        Transform newProjectile = Instantiate(projectile, transform.position, transform.rotation) as Transform;
        newProjectile.GetComponent<Projectile>().shooterIndex = playerIndex;
        newProjectile.transform.parent = projectiles.transform;
    }
}
