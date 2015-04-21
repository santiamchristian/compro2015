using UnityEngine;
using System.Collections;

public class Volcano : Projectile {
    public Transform FirePrefab;
    public int WavesToShoot = 4;
    public float CoolDownSpeed = 3;
    private GameObject projectiles;
    private int WavesShot;

	// Use this for initialization
	void Start () {
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



            Shoot(new Quaternion(0, 30, 0, 0));
            Shoot(new Quaternion(0, 60, 0, 0));
            Shoot(new Quaternion(0, 90, 0, 0));
            Shoot(new Quaternion(0, 120, 0, 0));
            Shoot(new Quaternion(0, 150, 0, 0));
            Shoot(new Quaternion(0, 180, 0, 0));
            Shoot(new Quaternion(0, 210, 0, 0));
            Shoot(new Quaternion(0, 240, 0, 0));
            Shoot(new Quaternion(0, 270, 0, 0));
            Shoot(new Quaternion(0, 300, 0, 0));
            Shoot(new Quaternion(0, 330, 0, 0));
            Shoot(new Quaternion(0, 360, 0, 0));
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
