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
    [SerializeField] private float _soundSpatialBlend = 0.75f;

    public ElectricDeviceState CurrentState { get; private set; }

    public enum ElectricDeviceState { ON, OFF }

    public Action OnTurnOff;

    private List<LampLight> _lights;
    protected AudioSource MyAudioSource { get; private set; }
    private bool _canPlay;

    protected virtual void Awake()
    {
        _lights = GetComponentsInChildren<LampLight>().ToList();
        MyAudioSource = GetComponent<AudioSource>();

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
        PlaySound(CurrentState == ElectricDeviceState.ON ? _turnOnSound : _turnOffSound);
    }

    protected void PlaySound(AudioClip sound)
    {
        if (_canPlay)
        {
            MyAudioSource.clip = sound;
            MyAudioSource.loop = false;
            MyAudioSource.pitch = UnityEngine.Random.Range(_soundMinPitch, _soundMaxPitch);
            MyAudioSource.spatialBlend = _soundSpatialBlend;
            MyAudioSource.Play();
        }
        _canPlay = true;
    }
}
