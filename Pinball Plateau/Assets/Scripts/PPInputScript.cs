using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PPInputScript : MonoBehaviour
{
    public delegate void MoveHandler(Vector2 movement);
    public event MoveHandler OnMoveEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        OnMoveEvent?.Invoke(move);
    }
}
