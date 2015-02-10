using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public MovementController[] players;


    void Start()
    {
        players = gameObject.GetComponentsInChildren<MovementController>();
    }

    void Update()
    {
        if (players[0] != null)
        {
            players[0].Direction(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetButton("Jump")) players[0].Jump();
            PopUpMenu("Cancel");
        }
    }

    protected void PopUpMenu(string buttonName)
    {
        if (Input.GetButtonUp(buttonName))
        {
            GameObject popUpMenu = GameObject.Find("PopUpMenu");

            if (popUpMenu == null)
            {

                Application.LoadLevelAdditive("PopUpMenu");

            }
            else
            {

                Destroy(popUpMenu);
            }
        }

    }


}
