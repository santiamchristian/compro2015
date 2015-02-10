using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int hp = 100;
    public bool isEnemy = true;

    // Use this for initialization
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Damage(1);
    }


}

