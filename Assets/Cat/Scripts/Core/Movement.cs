using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _myRigidbody;

    private Vector2 _workspace;

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private void Awake()
    {
        _myRigidbody = transform.parent.parent.GetComponentInParent<Rigidbody2D>();

        FacingDirection = 1;
    }

    private void Update() => CurrentVelocity = _myRigidbody.velocity;

    public void SetVelocityZero()
    {
        _workspace.Set(0.0f, 0.0f);
        SetFinalVelocity();
    }

    public void SetVelocityX(float velocityX)
    {
        _workspace.Set(velocityX, _myRigidbody.velocity.y);
        SetFinalVelocity();
    }

    public void SetVelocityY(float velocityY)
    {
        _workspace.Set(CurrentVelocity.x, velocityY);
        SetFinalVelocity();
    }

    public void SetFinalVelocity()
    {
        _myRigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (ShouldFlip(xInput))
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1;
        _myRigidbody.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private bool ShouldFlip(int xInput) => xInput != 0 && xInput != FacingDirection;
}
