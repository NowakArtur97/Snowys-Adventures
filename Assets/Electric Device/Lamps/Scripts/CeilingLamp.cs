using UnityEngine;

public class CeilingLamp : Lamp
{
    [SerializeField] private GameObject _lightSwitchOn;
    [SerializeField] private GameObject _lightSwitchOff;
    [SerializeField] private AudioClip _turnOnSound;
    [SerializeField] private AudioClip _turnOffSound;
    [SerializeField] private float _soundMinPitch = 0.75f;
    [SerializeField] private float _soundMaxPitch = 1.0f;

    private AudioSource _myAudioSource;

    protected override void Awake()
    {
        _myAudioSource = GetComponent<AudioSource>();

        base.Awake();
    }

    protected override void TurnOn()
    {
        base.TurnOn();

        ChangeState(true, _lightSwitchOff, _lightSwitchOn);
    }

    protected override void TurnOff()
    {
        base.TurnOff();

        ChangeState(false, _lightSwitchOn, _lightSwitchOff);
    }

    public override void Interact()
    {
        base.Interact();

        _myAudioSource.clip = CurrentState == ElectricDeviceState.ON ? _turnOnSound : _turnOffSound;
        _myAudioSource.pitch = Random.Range(_soundMinPitch, _soundMaxPitch);
        _myAudioSource.Play();
    }

    private void ChangeState(bool isOn, GameObject switchToEnable, GameObject switchToDisable)
    {
        switchToEnable.SetActive(true);
        switchToDisable.SetActive(false);
    }
}
