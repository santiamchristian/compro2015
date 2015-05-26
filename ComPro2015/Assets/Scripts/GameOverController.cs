using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {
    private bool gameOver = false;

	// Update is called once per frame
	void Update () {
        if (transform.childCount == 0 && !gameOver)
        {
            gameOver = true;
            Application.LoadLevelAdditive("GameOverMenu");
        }
	}
}
