using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int hp = 100;
    public bool isEnemy = true;
    public int playerIndex;

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
        playerIndex = transform.GetComponent<Player>().playerIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }




}

