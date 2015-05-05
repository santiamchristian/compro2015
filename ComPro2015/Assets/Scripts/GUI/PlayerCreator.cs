using UnityEngine;
using System.Collections;

public class PlayerCreator : MonoBehaviour {

    public Transform[] playerPrefabs = new Transform[4];
    public PlayerGui playerGui;
    public int index;

    private InputController inputController; 
   
	// Use this for initialization
	void Start () 
    {
        inputController = GameObject.Find("Players").GetComponent<InputController>();
        playerGui = GameObject.Find("PlayerGUICanvas").GetComponent<PlayerGui>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void AddPlayer(int type)
    {
        Transform newPlayer = Instantiate(playerPrefabs[(int)type], inputController.transform.position, Quaternion.identity) as Transform;
        newPlayer.parent = inputController.transform;
        Player playerComp = newPlayer.GetComponent<Player>();
        playerComp.playerIndex = index;
        inputController.players[index] = newPlayer.GetComponent<MovementController>();
        playerComp.playerGUI = playerGui.AddPlayer(index, (ElementEnum)type).GetComponent<GUi>();
        Destroy(gameObject);
    }

}
