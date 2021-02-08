using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPPlayerControllerScript : MonoBehaviour
{
    public PPInputScript InputManager;
    public Rigidbody Player;
    public float speed = 10f;

    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnMoveEvent += Move;
    }

    // Update is called once per frame
    void Update()
    {
        Player.AddForce(new Vector3(move.x, 0, move.y) * speed * Time.deltaTime);
    }

    void Move(Vector2 movement)
    {
        move = movement;
    }
}
