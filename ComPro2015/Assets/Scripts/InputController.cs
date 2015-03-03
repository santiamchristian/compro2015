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
            if(Input.GetButtonDown("Fire1")) Attack(0);
            players[0].RotateTowardsCursor();
        }

        for (int i = 0; i <= players.Length; i++)
        { 
            if (GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, (GamepadInput.GamePad.Index)i+1) > 0)
            {
                Attack(i);
            }
        }

    }

    protected void Attack(int index)
    {
            Ability ability = players[index].GetComponentInChildren<Ability>();
            ability.Use();
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
