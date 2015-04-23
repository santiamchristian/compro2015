using UnityEngine;
using System.Collections;

public class Tornado : Projectile {

    public float LaunchDistance = 10; 


    public override void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null)
            Destroy();

        else if (health.playerIndex != shooterIndex)
        {
            health.Damage(damage);
            
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<MovementController>().Launch(LaunchDistance);
        }
        
    }
}
