using UnityEngine;

public class CollisionSenses : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private Transform _plugInCheck;
    [SerializeField] private float _plugInCheckRadius = 0.3f;
    [SerializeField] private LayerMask _whatIsPlugableIn;

    [SerializeField] private Transform _plugOutCheck;
    [SerializeField] private float _plugOutCheckRadius = 0.3f;
    [SerializeField] private LayerMask _whatIsPlugableOut;

    public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);

    public bool IsPlugablInClose => Physics2D.OverlapCircle(_plugInCheck.position, _plugInCheckRadius, _whatIsPlugableIn);

    public Collider2D[] ClosePlugableIn => Physics2D.OverlapCircleAll(_plugInCheck.position, _plugInCheckRadius, _whatIsPlugableIn);

    public bool IsPlugablOutClose => Physics2D.OverlapCircle(_plugOutCheck.position, _plugOutCheckRadius, _whatIsPlugableOut);

    public Collider2D[] ClosePlugableOut => Physics2D.OverlapCircleAll(_plugOutCheck.position, _plugOutCheckRadius, _whatIsPlugableOut);
}
