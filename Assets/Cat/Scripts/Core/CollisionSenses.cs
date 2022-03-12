using UnityEngine;

public class CollisionSenses : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 2f;
    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckRadius = 2f;
    [SerializeField] private float _wallCheckDistance = 2f;
    [SerializeField] private LayerMask _whatIsWall;

    public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);

    public bool IsCloseToWall => Physics2D.Raycast(_wallCheck.position, transform.right, _wallCheckDistance, _whatIsGround);
}
