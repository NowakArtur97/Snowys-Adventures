using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CeilingLamp : ElectricDevice
{
    [SerializeField] private GameObject _lightSwitchOn;
    [SerializeField] private GameObject _lightSwitchOff;

    private readonly string LIGHT_OBJECT = "Light";
    private readonly string BULB_LIGHT_OBJECT = "Bulb Light";

    private Light2D _light;
    private Light2D _bulbLight;

    protected override void Awake()
    {
        _light = transform.Find(LIGHT_OBJECT).GetComponent<Light2D>();
        _bulbLight = transform.Find(BULB_LIGHT_OBJECT).GetComponent<Light2D>();

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

    private void ChangeState(bool isPluggedIn, GameObject switchToEnable, GameObject switchToDisable)
    {
        _light.gameObject.SetActive(isPluggedIn);
        _bulbLight.gameObject.SetActive(isPluggedIn);

        switchToEnable.SetActive(true);
        switchToDisable.SetActive(false);
    }
}
