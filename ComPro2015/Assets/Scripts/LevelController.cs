using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public GameObject loadingScreen;

    // Use this for initialization
    void Start()
    {
        loadLevel("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject debug = GameObject.Find("Debug");
        if (debug != null)
            Destroy(debug);
        GameObject level = GameObject.Find("Level");
        if (level!= null && Camera.main.transform.position.x == transform.position.x)
            Destroy(loadingScreen);
    }

    void loadLevel(string levelName)
    {
        Application.LoadLevelAdditive(levelName);

    }
 
}
