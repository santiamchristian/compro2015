using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);

    }
}
