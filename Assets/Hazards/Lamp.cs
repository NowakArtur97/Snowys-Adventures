using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lamp : ElectricDevice
{
    [SerializeField] private GameObject _wireEnd;
    [SerializeField] private Transform _electricalContactPostion;
    [SerializeField] private Transform _plugOutPostion;

    private readonly string LIGHT_OBJECT = "Light";
    private readonly string BULB_LIGHT_OBJECT = "Bulb Light";

    private Light2D _light;
    private Light2D _bulbLight;
    private BoxCollider2D _electricalContactBoxcollider2D;

    protected override void Awake()
    {
        _light = transform.Find(LIGHT_OBJECT).GetComponent<Light2D>();
        _bulbLight = transform.Find(BULB_LIGHT_OBJECT).GetComponent<Light2D>();
        _electricalContactBoxcollider2D = _electricalContactPostion.gameObject.GetComponent<BoxCollider2D>();

        base.Awake();
    }

    protected override void TurnOn()
    {
        base.TurnOn();

        ChangeState(true, _electricalContactPostion.position);
    }

    protected override void TurnOff()
    {
        base.TurnOff();

        ChangeState(false, _plugOutPostion.position);
    }

    private void ChangeState(bool isPluggedIn, Vector3 wireEndPosition)
    {
        _light.gameObject.SetActive(isPluggedIn);
        _bulbLight.gameObject.SetActive(isPluggedIn);

        _wireEnd.transform.position = wireEndPosition;

        _electricalContactBoxcollider2D.enabled = isPluggedIn;
        _plugOutPostion.gameObject.SetActive(!isPluggedIn);
    }
}
