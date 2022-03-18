using UnityEngine;

public class RobotVacuumCleaner : ElectricDevice
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float _speed = 6.0f;

    private bool _isMovingRight;

    protected override void Awake()
    {
        base.Awake();

        _isMovingRight = true;
    }

    private void Update()
    {
        if (CurrentState == ElectricDeviceState.ON)
        {
            Move();

            CheckChangeDirection();
        }
    }

    private void CheckChangeDirection()
    {
        if (transform.position.x <= pointA.transform.position.x)
        {
            _isMovingRight = true;
        }
        else if (transform.position.x >= pointB.transform.position.x)
        {
            _isMovingRight = false;
        }
    }

    private void Move()
    {
        if (_isMovingRight)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * _speed * Time.deltaTime);
        }
    }
}
