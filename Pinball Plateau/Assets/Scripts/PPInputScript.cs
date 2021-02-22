using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PPInputScript : MonoBehaviour
{
    //Initializes delegates for event handlers and event systems
    public delegate void MoveHandler(Vector2 movement);
    public delegate void TiltHandler(Quaternion tilt);
    public event MoveHandler OnMoveEvent;
    public event TiltHandler OnTiltEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        //Publishes the value as an event
        OnMoveEvent?.Invoke(move);
    }

    public void OnTilt(InputAction.CallbackContext context)
    {
        Quaternion TiltVector = context.ReadValue<Quaternion>();

        //Publishes the value as an event
        OnTiltEvent?.Invoke(TiltVector);
    }
}
