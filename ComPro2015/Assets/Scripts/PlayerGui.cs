using UnityEngine;
using System.Collections;

public class PlayerGui : MonoBehaviour {

    public Transform playerContainer;
    public RectTransform[] guiPositions = new RectTransform[5];
    private int previousPlayerCount =0  ;


	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        previousPlayerCount = playerContainer.transform.childCount;
	}

    void playerGui()
    {
        if (transform.childCount > previousPlayerCount)
        {
             
        }
    }
}
