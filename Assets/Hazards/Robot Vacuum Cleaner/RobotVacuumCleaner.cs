using UnityEngine;

public class RobotVacuumCleaner : ElectricDevice
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float _speed = 6.0f;

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

    private void Move() => transform.Translate(Vector2.right * -_speed * Time.deltaTime);

    private void Flip() => transform.Rotate(0, 180.0f, 0);

    private bool ShouldChangeDirection() => transform.position.x <= pointA.transform.position.x || transform.position.x >= pointB.transform.position.x;
}
