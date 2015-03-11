using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public MovementController[] players;
    public bool keyboard;
    public Transform playerPrefab;
    public int maxPlayers;

    void Start()
    {
        players = new MovementController[maxPlayers];
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

        for (int i = 1; i <= maxPlayers; i++)
        {
            if (players[i - 1] != null)
            {

                if (keyboard)
                    i++;
                if (GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, (GamepadInput.GamePad.Index)i) > 0)
                {
                    Attack(i);
                }

                players[i].Direction(GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, (GamepadInput.GamePad.Index)i));

                if (GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.A, (GamepadInput.GamePad.Index)i))
                {
                    players[i].Jump();
                }
                players[i].Rotate(GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, (GamepadInput.GamePad.Index)i));
            }
            else
            {
                if (GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.Start, (GamepadInput.GamePad.Index)i))
                {
                    AddPlayer(i - 1);
                }
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
    protected void AddPlayer(int index)
    {
        Transform newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity) as Transform;
        newPlayer.parent = transform;
    }



}
