using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    public Transform players;
    public float slerp = 5;

	void Start() 
    {
	    
	}
	
    void Update() 
    {
        FollowPlayers();
	}

    void FollowPlayers()
    {
        
        transform.position = Vector3.Slerp(transform.position, new Vector3(players.transform.position.x, transform.position.y, players.transform.position.z), slerp);
    }
}
