using System;
using UnityEngine;

public abstract class ElectricDevice : MonoBehaviour
{
    [SerializeField] private ElectricDeviceState _startingState = ElectricDeviceState.ON;

    public ElectricDeviceState CurrentState { get; private set; }

    public enum ElectricDeviceState { ON, OFF }

    public Action OnTurnOff;

    protected virtual void Awake()
    {
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

    protected virtual void TurnOn() => CurrentState = ElectricDeviceState.ON;

    protected virtual void TurnOff()
    {
        CurrentState = ElectricDeviceState.OFF;
        OnTurnOff?.Invoke();
    }
}
