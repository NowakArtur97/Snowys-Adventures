using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public Vector2 Movement { get; private set; }
    public bool IsJumping { get; private set; }

    public void OnMove(InputAction.CallbackContext context) => Movement = context.ReadValue<Vector2>();

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsJumping = true;
        }
        else if (context.canceled)
        {
            IsJumping = false;
        }
    }
}
