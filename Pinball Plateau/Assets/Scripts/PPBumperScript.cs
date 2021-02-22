using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPBumperScript : MonoBehaviour
{
    //Grabs the player's rigidbody
    public Rigidbody Player;
    public float BumperForce = 100f;

    //Grabs an instance of the Ground tilt script
    public PPGroundTiltScript ground;
    
    //Grabs the current forces on the Player
    public PPPlayerControllerScript velocity;

    //Grabs the score script
    public PPScoreScript Score;
    

    private void OnCollisionEnter(Collision collision)
    {

        //Checks for collision, checks tag for player
        if (collision.gameObject.tag == "Player")
        {
            //If Player adds a force in 180 degrees from the player velocity direction and magnitude
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, 180, 0) * collision.gameObject.GetComponent<Rigidbody>().velocity * BumperForce);
            Score.score += 100;
        }

        if (Score.score % 500 == 0 && Score.score >= 500)
        {
            GameObject newBall = GameObject.Instantiate(collision.gameObject);

            newBall.transform.position = new Vector3(0, 5, 0);

            ground.ballCount++;
        }
    }
}
