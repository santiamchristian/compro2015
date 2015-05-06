using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int hp = 100;
    int maxHP;
    public bool isEnemy = true;
    public int playerIndex;
    public GUi gui;

    // Use this for initialization
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            gui.Destroy();
            Destroy(gameObject);
        }
    }

    void Start()
    {
        maxHP = hp;
        playerIndex = transform.GetComponent<Player>().playerIndex;
        gui = transform.GetComponent<Player>().playerGUI;
    }

    // Update is called once per frame
    void Update()
    {
        gui.SetHealthBar(hp, maxHP);
    }




}

