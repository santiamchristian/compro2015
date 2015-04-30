using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public MovementController[] players;
    public Transform playerPrefab;
    public bool asManyPlayersAsControllers = true;
    public int maxPlayers = 5;
    public PlayerGui playerGui;
    public Transform charatorCreatorPrefab;
    Transform charactorCreatorMenu;

    void Start()
    {
        if (asManyPlayersAsControllers)
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
            if (Input.GetButtonDown("Fire1")) Attack(maxPlayers - 1, 0);
            if (Input.GetButtonDown("Fire2")) Attack(maxPlayers - 1, 1);
            if (Input.GetButtonDown("Fire3")) Attack(maxPlayers - 1, 2);
            if (Input.GetButtonDown("Fire4")) Attack(maxPlayers - 1, 3);
            players[maxPlayers - 1].RotateTowardsCursor();
            players[maxPlayers - 1].Direction(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        else
        {
            if (Input.GetButtonUp("Cancel"))
            {
                CharacterCreatorMenu(maxPlayers - 1);
            }

        }

        for (int i = 0; i < (maxPlayers - 1); i++)
        {
            GamepadInput.GamepadState gamePad = GamepadInput.GamePad.GetState((GamepadInput.GamePad.Index)(i + 1));
            if (players[i] != null)
            {
                players[i].Direction(gamePad.LeftStickAxis);

                if (gamePad.A)
                {
                    players[i].Jump();
                }
                players[i].Rotate(gamePad.rightStickAxis);
                if (gamePad.RightTrigger > 0)
                {
                    Attack(i, 0);
                }
            }
            else
            {
                if (gamePad.Start)
                {
                    CharacterCreatorMenu(i);
                }
            }
        }

    }

    protected void Attack(int index, int attackType)
    {
        Ability ability = players[index].GetComponentInChildren<Ability>();
        ability.Use(attackType);
    }

    protected void CharacterCreatorMenu(int index)
    {
        if (charactorCreatorMenu == null)
        {
            charactorCreatorMenu = Instantiate(charatorCreatorPrefab) as Transform;
            charactorCreatorMenu.GetComponent<PlayerCreator>().index = index;
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

    public void AddPlayerToInput(int type, int index)
    {
        //Transform newPlayer = Instantiate(playerGuiPrefabs[type], transform.position, Quaternion.identity) as Transform;
        //newPlayer.parent = transform;
        //newPlayer.GetComponent<Player>().playerIndex = index;
        //players[index] = newPlayer.GetComponent<MovementController>();
        //playerGui.AddPlayer(index, (ElementEnum)type);
    }




}
