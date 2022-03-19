using UnityEngine;

public class RobotVacuumCleaner : ElectricDevice
{
    private readonly string MOVE_ANIMATION_BOOL_NAME = "move";

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 6.0f;

    private Animator _myAnimator;

    protected override void Awake()
    {
        _myAnimator = GetComponent<Animator>();

        base.Awake();
    }

    private void Update()
    {
        if (CurrentState == ElectricDeviceState.ON)
        {
            Move();

            if (ShouldChangeDirection())
            {
                Flip();
            }
        }
    }

    protected override void ChangeState(bool isOn)
    {
        base.ChangeState(isOn);

        _myAnimator.SetBool(MOVE_ANIMATION_BOOL_NAME, isOn);
    }

    private void Move() => transform.Translate(Vector2.right * -_speed * Time.deltaTime);

    private void Flip() => transform.Rotate(0, 180.0f, 0);

    private bool ShouldChangeDirection() => transform.position.x <= _pointA.transform.position.x || transform.position.x >= _pointB.transform.position.x;
}
