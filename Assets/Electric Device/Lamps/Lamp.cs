using System.Linq;
using UnityEngine;

public abstract class Lamp : ElectricDevice
{
    [SerializeField] private GameObject[] _objectsToInteract;

    private PolygonCollider2D _lightCheckerPolygonCollider2D;

    protected override void Awake()
    {
        _lightCheckerPolygonCollider2D = GetComponentInChildren<PolygonCollider2D>();

        base.Awake();
    }

    protected override void ChangeState(bool isOn)
    {
        base.ChangeState(isOn);

        _lightCheckerPolygonCollider2D.gameObject.SetActive(isOn);

        _objectsToInteract.ToList()
            .ForEach(toInteract => toInteract.SetActive(isOn));
    }
}
