using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public GameObject loadingScreen;
	// Use this for initialization
    IEnumerator Start()
    {
        AsyncOperation async = Application.LoadLevelAdditiveAsync("Terrain");
        yield return async;
        Debug.Log("Loading complete");
    }
	
	// Update is called once per frame
	void Update () {
        GameObject debug = GameObject.Find("Debug");
        if (debug != null)
            Destroy(debug);
	}

 
}
