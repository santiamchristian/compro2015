using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {
    public Transform[] abilities = new Transform[4];
    private int playerIndex;
    private GUi gui;
    private GameObject projectiles;
    private float[] ElapsedTimes = new float[4];
    public Transform[] startLocations = new Transform[4];

    void Start()
    {
        playerIndex = transform.parent.GetComponent<Player>().playerIndex;
        gui = transform.parent.GetComponent<Player>().playerGUI;
        projectiles = GameObject.Find("Projectiles");
        for (int i = 0; i < ElapsedTimes.Length; i++)
        {
            ElapsedTimes[i] = abilities[i].GetComponent<Projectile>().coolDown;
        }
    }
	void Update () 
    {
        for (int i = 0; i < ElapsedTimes.Length; i++)
        {
            ElapsedTimes[i] += Time.deltaTime;
            gui.SetAbilityCooldown(ElapsedTimes[i] / abilities[i].GetComponent<Projectile>().coolDown, i);
            
        }
	}

    public void Use(int i)
    {
        if (abilities[i].GetComponent<Projectile>().coolDown <= ElapsedTimes[i])
        {
            Transform newProjectile;
            if(startLocations[i] != null)
             newProjectile = Instantiate(abilities[i], startLocations[i].position, transform.rotation) as Transform;
            else
            newProjectile = Instantiate(abilities[i], transform.position, transform.rotation) as Transform;
            newProjectile.GetComponent<Projectile>().shooterIndex = playerIndex;
            newProjectile.transform.parent = projectiles.transform;
            ElapsedTimes[i] = 0;
        }
    }
}
