using System.Collections;
using UnityEngine;

public class MotionSensorLamp : Lamp
{
    [SerializeField] private float _ligtingTime = 3.0f;
    [SerializeField] private float _detectionDistance = 10.0f;
    [SerializeField] private LayerMask _whatIsDetected;

    private void Update()
    {
        if (_isDetecting && CurrentState != ElectricDeviceState.ON)
        {
            StartCoroutine(LightDelayCoroutine());
        }
    }

    private IEnumerator LightDelayCoroutine()
    {
        TurnOn();

        yield return new WaitForSeconds(_ligtingTime);

        if (_isDetecting)
        {
            yield return StartCoroutine(LightDelayCoroutine());
        }

        TurnOff();
    }

    private bool _isDetecting => Physics2D.Raycast(gameObject.transform.position, Vector2.down, _detectionDistance, _whatIsDetected);
}
