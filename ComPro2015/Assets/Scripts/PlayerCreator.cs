﻿using UnityEngine;
using System.Collections;

public class PlayerCreator : MonoBehaviour {

    public Transform[] playerPrefabs = new Transform[4];
    public PlayerGui playerGui;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void AddPlayer(MovementController[] players, int index, ElementEnum type)
    {
        Transform newPlayer = Instantiate(playerPrefabs[(int)type], transform.position, Quaternion.identity) as Transform;
        newPlayer.parent = transform;
        newPlayer.GetComponent<Player>().playerIndex = index;
        players[index] = newPlayer.GetComponent<MovementController>();
        playerGui.AddPlayer(index, type);
    }

}
