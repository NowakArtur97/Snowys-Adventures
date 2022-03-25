using System.Collections;
using UnityEngine;

public class BlinkingLamp : Lamp
{
    [SerializeField] private float _ligtingTime = 1.5f;
    [SerializeField] private float _restTime = 1.5f;

    private bool _isInCoroutine;

    private void Update()
    {
        if (!_isInCoroutine)
        {
            if (CurrentState == ElectricDeviceState.ON)
            {
                StartCoroutine(TurnOffCoroutine());
            }
            else
            {
                StartCoroutine(TurnOnCoroutine());
            }
        }
    }

    private IEnumerator TurnOnCoroutine()
    {
        _isInCoroutine = true;

        TurnOn();

        yield return new WaitForSeconds(_ligtingTime);

        TurnOff();

        yield return new WaitForSeconds(_restTime);

        _isInCoroutine = false;
    }

    private IEnumerator TurnOffCoroutine()
    {
        _isInCoroutine = true;

        TurnOff();

        yield return new WaitForSeconds(_restTime);

        TurnOn();

        yield return new WaitForSeconds(_ligtingTime);

        _isInCoroutine = false;
    }
}
