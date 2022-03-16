using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Lamp : ElectricDevice
{
    private readonly string LIGHT_OBJECT = "Light";
    private readonly string BULB_LIGHT_OBJECT = "Bulb Light";

    [SerializeField] private float _intensityOn = 0.7f;
    [SerializeField] private float _intensityOff = 0f;

    protected Light2D MainLight { get; private set; }
    protected Light2D BulbLight { get; private set; }
    private PolygonCollider2D _lightCheckerPolygonCollider2D;

    protected override void Awake()
    {
        MainLight = transform.Find(LIGHT_OBJECT).GetComponent<Light2D>();
        BulbLight = transform.Find(BULB_LIGHT_OBJECT).GetComponent<Light2D>();
        _lightCheckerPolygonCollider2D = GetComponentInChildren<PolygonCollider2D>();

        base.Awake();
    }

    protected void ChangeState(bool isOn)
    {
        MainLight.intensity = isOn ? _intensityOn : _intensityOff;
        BulbLight.intensity = isOn ? _intensityOn : _intensityOff;

        _lightCheckerPolygonCollider2D.gameObject.SetActive(isOn);
    }
}
