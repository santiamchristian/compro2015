using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int speed;
    public int shooterIndex;
    public int damage;
    public float duration = 30;
    private float elapsedTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        rigidbody.velocity = transform.TransformDirection(Vector3.forward) * speed;
        if (elapsedTime >= duration)
            Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null)
            Destroy();
        else if (health.playerIndex != shooterIndex)
        {
            health.Damage(damage);
            Destroy();
        }

    }
}
