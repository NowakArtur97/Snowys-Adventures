using UnityEngine;

public class LampWithWire : Lamp
{
    [SerializeField] private GameObject _wireEnd;
    [SerializeField] private Transform _electricalContactPostion;
    [SerializeField] private Transform _plugOutPostion;

    private BoxCollider2D _electricalContactBoxcollider2D;

    protected override void Awake()
    {
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

    private void ChangeState(bool isOn, Vector3 wireEndPosition)
    {
        ChangeState(isOn);

        _wireEnd.transform.position = wireEndPosition;

        _electricalContactBoxcollider2D.enabled = isOn;
        _plugOutPostion.gameObject.SetActive(!isOn);
    }
}
