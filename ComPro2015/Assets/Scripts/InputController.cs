using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public MovementController[] players;
    public bool keyboard;

    void Start()
    {
        players = gameObject.GetComponentsInChildren<MovementController>();
    }

    void Update()
    {
        if (keyboard && players[0] != null)
        {
            if (Input.GetButton("Jump")) players[0].Jump();
            PopUpMenu("Cancel");
            if(Input.GetButtonDown("Fire1")) Attack(0);
            players[0].RotateTowardsCursor();
            players[0].Direction(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }

        for (int i = 0; i < players.Length; i++)
        {
            if (keyboard)
                i++;
            if (GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, (GamepadInput.GamePad.Index)i+1) > 0)
            {
                Attack(i);
            }

            players[i].Direction(GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, (GamepadInput.GamePad.Index)i + 1));

            if (GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.A, (GamepadInput.GamePad.Index)i + 1))
            {
                players[i].Jump();
            }
            players[i].Rotate(GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, (GamepadInput.GamePad.Index)i + 1));
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
