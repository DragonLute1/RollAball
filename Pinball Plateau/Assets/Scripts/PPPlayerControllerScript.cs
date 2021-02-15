using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPPlayerControllerScript : MonoBehaviour
{
    public PPInputScript InputManager;
    public Rigidbody Player;
    public float speed = 10f;

    public Vector3 currentForces;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, new Vector3(0, -1, 0), out RaycastHit hit, Mathf.Infinity)){
            Debug.Log("Raycast");
            Destroy(this.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        currentForces = new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
        Player.AddForce(currentForces);
    }

    void Move(Vector2 movement)
    {
        move = movement;
    }
}
