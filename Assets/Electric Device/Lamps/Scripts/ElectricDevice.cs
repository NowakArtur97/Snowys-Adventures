using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ElectricDevice : MonoBehaviour
{
    [SerializeField] private ElectricDeviceState _startingState = ElectricDeviceState.ON;
    [SerializeField] private AudioClip _turnOnSound;
    [SerializeField] private AudioClip _turnOffSound;
    [SerializeField] private float _soundMinPitch = 0.8f;
    [SerializeField] private float _soundMaxPitch = 1.0f;

    public ElectricDeviceState CurrentState { get; private set; }

    public enum ElectricDeviceState { ON, OFF }

    public Action OnTurnOff;

    private List<LampLight> _lights;
    private AudioSource _myAudioSource;
    private bool _canPlay;

    protected virtual void Awake()
    {
        _lights = GetComponentsInChildren<LampLight>().ToList();
        _myAudioSource = GetComponent<AudioSource>();

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

    protected virtual void ChangeState(bool isOn)
    {
        _lights.ForEach(light => light.ChangeIntensity(isOn));
        PlaySound();
    }

    private void PlaySound()
    {
        if (_canPlay)
        {
            _myAudioSource.clip = CurrentState == ElectricDeviceState.ON ? _turnOnSound : _turnOffSound;
            _myAudioSource.pitch = UnityEngine.Random.Range(_soundMinPitch, _soundMaxPitch);
            _myAudioSource.Play();
        }
        _canPlay = true;
    }
}
