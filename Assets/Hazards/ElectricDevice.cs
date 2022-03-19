using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class ElectricDevice : MonoBehaviour
{
    private readonly string LIGHT_OBJECT = "Light";
    private readonly string BULB_LIGHT_OBJECT = "Bulb Light";

    [SerializeField] private ElectricDeviceState _startingState = ElectricDeviceState.ON;
    [SerializeField] private float _intensityOn = 0.7f;
    [SerializeField] private float _intensityOff = 0f;

    public ElectricDeviceState CurrentState { get; private set; }

    public enum ElectricDeviceState { ON, OFF }

    public Action OnTurnOff;

    private Light2D _mainLight;
    private Light2D _bulbLight;

    protected virtual void Awake()
    {
        _mainLight = transform.Find(LIGHT_OBJECT).GetComponent<Light2D>();
        _bulbLight = transform.Find(BULB_LIGHT_OBJECT).GetComponent<Light2D>();

        CurrentState = _startingState;

        if (CurrentState == ElectricDeviceState.ON)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    public virtual void Interact()
    {
        if (CurrentState == ElectricDeviceState.OFF)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }

    protected virtual void TurnOn()
    {
        CurrentState = ElectricDeviceState.ON;
        ChangeState(true);
    }

    protected virtual void TurnOff()
    {
        CurrentState = ElectricDeviceState.OFF;
        OnTurnOff?.Invoke();
        ChangeState(false);
    }

    protected virtual void ChangeState(bool isOn)
    {
        _mainLight.intensity = isOn ? _intensityOn : _intensityOff;
        _bulbLight.intensity = isOn ? _intensityOn : _intensityOff;
    }
}
