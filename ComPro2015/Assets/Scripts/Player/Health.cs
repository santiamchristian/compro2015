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
            if (gui != null)
                gui.Destroy();
            Destroy(gameObject);
        }
    }

    void Start()
    {
        maxHP = hp;

        if (!isEnemy)
        {
            playerIndex = transform.GetComponent<Player>().playerIndex;
            gui = transform.GetComponent<Player>().playerGUI;
        }

    }

    public void Kill()
    {
        Damage(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (gui != null)
        {
            gui.SetHealthBar(hp, maxHP);
        }
        
    }




}

