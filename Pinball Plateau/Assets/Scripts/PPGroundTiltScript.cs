using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPGroundTiltScript : MonoBehaviour
{
    //Instantiates an instance of the input script as an input manager
    public PPInputScript InputManager;

    //Float for the speed of tilting. Adjustable
    public float speed = 10f;

    //Placeholder variables
    Quaternion tilt;
    Vector2 move;
    float angleX = 0;
    float angleZ = 0;

    public int ballCount = 1;
    public GameObject reset;

    // Start is called before the first frame update
    void Start()
    {
        //Subscribes to the Move event
        InputManager.OnMoveEvent += Move;
        //Subscribes to the Tilt event
        InputManager.OnTiltEvent += Tilt;
    }

    // Update is called once per frame
    void Update()
    {
        angleX += move.y * speed * Time.deltaTime;
        Mathf.Clamp(angleX, -45, 45);

        angleZ -= move.x * speed * Time.deltaTime;
        Mathf.Clamp(angleZ, -45, 45);

        transform.rotation = Quaternion.Euler(angleX, 0, angleZ);

        if (ballCount <= 0)
        {
            reset.SetActive(true);
        }
        
    }

    void Move(Vector2 movement)
    {
        //Brings the event into scope of the class
        move = movement;
    }

    void Tilt(Quaternion TiltVector)
    {
        //Brings the event into scope of the class
        tilt = TiltVector;
    }
}
