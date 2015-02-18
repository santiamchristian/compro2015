using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        loadLevel("Terrain");
	}
	
	// Update is called once per frame
	void Update () {
        GameObject debug = GameObject.Find("Debug");
        if (debug != null)
            Destroy(debug);
	}

    void loadLevel(string levelName)
    {
        Application.LoadLevelAdditive(levelName);

    }
}
