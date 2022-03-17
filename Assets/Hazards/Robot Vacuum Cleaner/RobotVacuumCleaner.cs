using UnityEngine;

public class RobotVacuumCleaner : ElectricDevice
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float _speed = 6.0f;

    private bool dirRight = true;

    private void Update()
    {
        if (CurrentState == ElectricDeviceState.ON)
        {
            if (dirRight)
            {
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * _speed * Time.deltaTime);
            }

            if (transform.position.x <= pointA.transform.position.x)
            {
                dirRight = true;
            }
            else if (transform.position.x >= pointB.transform.position.x)
            {
                dirRight = false;
            }
        }
    }
}
