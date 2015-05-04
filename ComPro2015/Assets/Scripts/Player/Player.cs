using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public int playerIndex;
    public RectTransform playerGUI;
    public RectTransform lifeBar;

    void Start()
    {
        lifeBar = playerGUI;
    }
}
