using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public GameObject playerSpawn;

    private GameObject players;
    private bool busy = false;

    // Use this for initialization
    void Start()
    {
        loadLevel("Game");
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.Find("Players");
        if (players != null && !busy)
        {
            busy = true;
            players.transform.position = playerSpawn.transform.position; 
            
        }
        if (players != null &&Camera.main.transform.position.x == players.transform.position.x)
            Destroy(gameObject);
            
    }

    void loadLevel(string levelName)
    {
        Application.LoadLevelAdditive(levelName);

    }
 
}
