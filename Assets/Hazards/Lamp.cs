using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Lamp : ElectricDevice
{
    private readonly string LIGHT_OBJECT = "Light";
    private readonly string BULB_LIGHT_OBJECT = "Bulb Light";

    [SerializeField] private float _intensityOn = 0.7f;
    [SerializeField] private float _intensityOff = 0f;

    private Light2D _mainLight;
    private Light2D _bulbLight;
    private PolygonCollider2D _lightCheckerPolygonCollider2D;

    protected override void Awake()
    {
        _mainLight = transform.Find(LIGHT_OBJECT).GetComponent<Light2D>();
        _bulbLight = transform.Find(BULB_LIGHT_OBJECT).GetComponent<Light2D>();
        _lightCheckerPolygonCollider2D = GetComponentInChildren<PolygonCollider2D>();

        base.Awake();
    }

    protected override void TurnOn()
    {
        base.TurnOn();

        ChangeState(true);
    }

    protected override void TurnOff()
    {
        base.TurnOff();

        ChangeState(false);
    }

    private void ChangeState(bool isOn)
    {
        _mainLight.intensity = isOn ? _intensityOn : _intensityOff;
        _bulbLight.intensity = isOn ? _intensityOn : _intensityOff;

        _lightCheckerPolygonCollider2D.gameObject.SetActive(isOn);
    }
}
