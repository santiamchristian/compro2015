using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public MovementController[] players;

    void Start()
    {
        players = gameObject.GetComponentsInChildren<MovementController>();
    }

    void Update()
    {
        if (players[0] != null)
        {
            players[0].Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            if (Input.GetButton("Jump")) players[0].Jump();
        }
    }
}
