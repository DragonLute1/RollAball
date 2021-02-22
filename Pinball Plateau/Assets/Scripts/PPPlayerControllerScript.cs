using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPPlayerControllerScript : MonoBehaviour
{
    //Instantiates an instance of the input script as an input manager
    public PPInputScript InputManager;
    //Grabs a reference to the Player's rigidbody
    public Rigidbody Player;
    public float speed = 10f;

    //Grabs an instance of the Ground tilt script
    public PPGroundTiltScript ground;

    public Vector3 currentForces;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        //Subscribes to the move event
        InputManager.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        //Checks to see if the player is off the plateau. If they are, start a coroutine
        if (!Physics.Raycast(transform.position, new Vector3(0, -1, 0), out RaycastHit hit, Mathf.Infinity)){
            Debug.Log("Raycast");
            StartCoroutine(BallFall());
        }
        else
        {
            StopCoroutine(BallFall());
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //Sums up the total forces on the Player and adds the force to the rigidbody
        currentForces = new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
        Player.AddForce(currentForces);
    }

    IEnumerator BallFall()
    {
        //Waits for X seconds and then performs the raycast check again. If off the plateau, destroy the player object
        yield return new WaitForSeconds(1.5f);
        if (!Physics.Raycast(transform.position, new Vector3(0, -1, 0), out RaycastHit hit, Mathf.Infinity))
        {
            Debug.Log("Raycast");
            ground.ballCount--;
            Destroy(this.gameObject);
        }
        
    }

    void Move(Vector2 movement)
    {
        //Brings the move event variable into scope
        move = movement;
    }
}
