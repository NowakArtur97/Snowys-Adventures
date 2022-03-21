using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ElectricDevice : MonoBehaviour
{
    [SerializeField] private ElectricDeviceState _startingState = ElectricDeviceState.ON;

    public ElectricDeviceState CurrentState { get; private set; }

    public enum ElectricDeviceState { ON, OFF }

    public Action OnTurnOff;

    private List<LampLight> _lights;

    protected virtual void Awake()
    {
        _lights = GetComponentsInChildren<LampLight>().ToList();

        CurrentState = _startingState;
    }

    private void Start()
    {
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

    protected virtual void ChangeState(bool isOn) => _lights.ForEach(light => light.ChangeIntensity(isOn));
}
