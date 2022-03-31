using System.Collections;
using UnityEngine;

public class MotionSensorLamp : Lamp
{
    [SerializeField] private float _ligtingTime = 1.5f;
    [SerializeField] private float _detectionDistance = 10.0f;
    [SerializeField] private LayerMask _whatIsDetected;
    [SerializeField] private Transform _rayPosition;
    [SerializeField] private Color _rayColor = Color.red;
    [SerializeField] private float _rayEndPositionYOffset = 10.0f;
    [SerializeField] private float _rayWidth = 0.1f;

    private LineRenderer _myLineRenderer;

    protected override void Awake()
    {
        SetupRay();

        base.Awake();
    }

    private void Update()
    {
        if (_isDetecting && CurrentState != ElectricDeviceState.ON)
        {
            StartCoroutine(LightDelayCoroutine());
        }
    }

    protected override void ChangeState(bool isOn)
    {
        base.ChangeState(isOn);

        _myLineRenderer.enabled = !isOn;
    }

    private IEnumerator LightDelayCoroutine()
    {
        if (CurrentState != ElectricDeviceState.ON)
        {
            TurnOn();
        }

        yield return new WaitForSeconds(_ligtingTime);

        if (_isDetecting)
        {
            yield return StartCoroutine(LightDelayCoroutine());
        }

        TurnOff();
    }

    private void SetupRay()
    {
        _myLineRenderer = GetComponent<LineRenderer>();

        Vector3[] positions = new Vector3[2];
        positions[0] = _rayPosition.position;
        positions[0] = _rayPosition.position;
        Vector3 endPosition = new Vector3(_rayPosition.position.x, _rayPosition.position.y - _rayEndPositionYOffset);
        positions[1] = endPosition;
        _myLineRenderer.positionCount = positions.Length;
        _myLineRenderer.SetPositions(positions);

        _myLineRenderer.startColor = _rayColor;
        _myLineRenderer.endColor = _rayColor;

        _myLineRenderer.startWidth = _rayWidth;
        _myLineRenderer.endWidth = _rayWidth;
    }

    private bool _isDetecting => Physics2D.Raycast(gameObject.transform.position, Vector2.down, _detectionDistance, _whatIsDetected);
}
