using System;
using System.Collections;
using UnityEngine;

public class RobotVacuumCleaner : ElectricDevice
{
    private readonly string MOVE_ANIMATION_BOOL_NAME = "move";

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _timeBeforeRotating = 1.0f;

    private Animator _myAnimator;
    private bool _canRotate;

    protected override void Awake()
    {
        _myAnimator = GetComponent<Animator>();

        _canRotate = true;

        base.Awake();
    }

    private void Update()
    {
        if (CurrentState == ElectricDeviceState.ON)
        {
            Move();

            if (ShouldChangeDirection() && _canRotate)
            {
                Flip();
                StartCoroutine(RotateCoroutine());
            }
        }
    }

    private IEnumerator RotateCoroutine()
    {
        _canRotate = false;

        yield return new WaitForSeconds(_timeBeforeRotating);

        _canRotate = true;
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
