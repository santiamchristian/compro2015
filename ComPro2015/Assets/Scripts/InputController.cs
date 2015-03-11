using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public MovementController[] players;
    public Transform playerPrefab;
    public bool asManyPlayersAsControllers = true;
    public int maxPlayers = 5;

    void Start()
    {
        if(asManyPlayersAsControllers)
            if (Input.GetJoystickNames().Length > maxPlayers)
                maxPlayers = Input.GetJoystickNames().Length + 1;
        players = new MovementController[maxPlayers];
    }

    void Update()
    {
        if (players[maxPlayers - 1] != null)
        {
            if (Input.GetButton("Jump")) players[maxPlayers - 1].Jump();
            PopUpMenu("Cancel");
            if (Input.GetButtonDown("Fire1")) Attack(maxPlayers - 1);
            players[maxPlayers - 1].RotateTowardsCursor();
            players[maxPlayers - 1].Direction(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        else
        {
            if(Input.GetButtonUp("Cancel")) 
                AddPlayer(maxPlayers - 1);
        }

        for (int i = 0; i < maxPlayers - 1; i++)
        {
            GamepadInput.GamePad.Index gamePadIndex = (GamepadInput.GamePad.Index)(i + 1);
            if (players[i] != null)
            {
                if (GamepadInput.GamePad.GetTrigger(GamepadInput.GamePad.Trigger.RightTrigger, gamePadIndex) > 0)
                {
                    Attack(i);
                }

                players[i].Direction(GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick, gamePadIndex));

                if (GamepadInput.GamePad.GetButton(GamepadInput.GamePad.Button.A, gamePadIndex))
                {
                    players[i].Jump();
                }
                players[i].Rotate(GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.RightStick, gamePadIndex));
            }
            else
            {
                if (GamepadInput.GamePad.GetButtonUp(GamepadInput.GamePad.Button.Start, gamePadIndex))
                {
                    AddPlayer(i);
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
        newPlayer.GetComponent<Player>().playerIndex = index;
        players[index] = newPlayer.GetComponent<MovementController>();
    }



}
