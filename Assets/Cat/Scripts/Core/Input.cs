using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    [SerializeField] private bool _canMove = true;
    [SerializeField] private bool _canJump = true;

    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool InteractInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_canMove)
        {
            MovementInput = context.ReadValue<Vector2>();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && _canJump)
        {
            JumpInput = true;
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
        }
        else if (context.canceled)
        {
            InteractInput = false;
        }
    }

    public void UseInteractInput() => InteractInput = false;
}
