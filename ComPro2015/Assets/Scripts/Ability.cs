using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {
    public Transform projectile;
    private int playerIndex;
    private GameObject projectiles;
    private float ElapsedTime;
    public float coolDown = 1;

    void Start()
    {
        playerIndex = transform.parent.GetComponent<Player>().playerIndex;
        projectiles = GameObject.Find("Projectiles");
    }
	void Update () 
    {
        ElapsedTime += Time.deltaTime;
	}

    public void Use()
    {
        if (coolDown <= ElapsedTime)
        {

            Transform newProjectile = Instantiate(projectile, transform.position, transform.rotation) as Transform;
            newProjectile.GetComponent<Projectile>().shooterIndex = playerIndex;
            newProjectile.transform.parent = projectiles.transform;
            ElapsedTime = 0;
        }
    }
}
