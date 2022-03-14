using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context) => MovementInput = context.ReadValue<Vector2>();

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }
}