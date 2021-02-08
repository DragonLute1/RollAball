using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPGroundTiltScript : MonoBehaviour
{
    public PPInputScript InputManager;
    public float speed = 10f;
    Vector2 move;
    float angleX = 0;
    float angleZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnMoveEvent += Move;
    }

    // Update is called once per frame
    void Update()
    {
        angleX += move.y * speed * Time.deltaTime;
        Mathf.Clamp(angleX, -45, 45);

        angleZ -= move.x * speed * Time.deltaTime;
        Mathf.Clamp(angleZ, -45, 45);

        transform.rotation = Quaternion.Euler(angleX, 0, angleZ);
    }

    void Move(Vector2 movement)
    {
        move = movement;
    }
}
