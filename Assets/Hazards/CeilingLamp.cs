using UnityEngine;

public class CeilingLamp : Lamp
{
    [SerializeField] private GameObject _lightSwitchOn;
    [SerializeField] private GameObject _lightSwitchOff;


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

    private void ChangeState(bool isOn, GameObject switchToEnable, GameObject switchToDisable)
    {
        ChangeState(isOn);

        switchToEnable.SetActive(true);
        switchToDisable.SetActive(false);
    }
}
