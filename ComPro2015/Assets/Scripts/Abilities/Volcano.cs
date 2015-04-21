using UnityEngine;
using System.Collections;

public class Volcano : Projectile {
    public Transform FirePrefab;
    public int WavesToShoot = 4;
    public float CoolDownSpeed = 3;
    private GameObject projectiles;
    private int WavesShot;

	// Use this for initialization
	public override void Start () {
        projectiles = GameObject.Find("Projectiles");
	}
	
	// Update is called once per frame
	public override void Update () {
        elapsedTime += Time.deltaTime;
        if (CoolDownSpeed <= elapsedTime)

        {

            if (WavesShot >= WavesToShoot)
            {
                Destroy();
            }



            Shoot(Quaternion.Euler(0, 30, 0));
            Shoot(Quaternion.Euler(0, 60, 0));
            Shoot(Quaternion.Euler(0, 90, 0));
            Shoot(Quaternion.Euler(0, 120, 0));
            Shoot(Quaternion.Euler(0, 150, 0));
            Shoot(Quaternion.Euler(0, 180, 0));
            Shoot(Quaternion.Euler(0, 210, 0));
            Shoot(Quaternion.Euler(0, 240, 0));
            Shoot(Quaternion.Euler(0, 270, 0));
            Shoot(Quaternion.Euler(0, 300, 0));
            Shoot(Quaternion.Euler(0, 330, 0));
            Shoot(Quaternion.Euler(0, 360, 0));
            WavesShot++;
            elapsedTime = 0;
        }

       

	}

    public void Shoot(Quaternion direction)
    {
       
            Transform newProjectile = Instantiate(FirePrefab, transform.position, direction) as Transform;
            newProjectile.GetComponent<Projectile>().shooterIndex = shooterIndex;
            newProjectile.transform.parent = projectiles.transform;
        
    }
}
