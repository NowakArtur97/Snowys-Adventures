using UnityEngine;

public class CollisionSenses : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 1f;
    [SerializeField] private LayerMask _whatIsGround;

    public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);
}
