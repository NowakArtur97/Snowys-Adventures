using System.Linq;
using UnityEngine;

public abstract class Lamp : ElectricDevice
{
    [SerializeField] private GameObject[] _objectsToInteract;

    private Collider2D _lightCheckerCollider2D;

    protected override void Awake()
    {
        _lightCheckerCollider2D = GetComponentInChildren<Collider2D>();

        base.Awake();
    }

    protected override void ChangeState(bool isOn)
    {
        base.ChangeState(isOn);

        _lightCheckerCollider2D.gameObject.SetActive(isOn);

        _objectsToInteract.ToList()
            .ForEach(toInteract => toInteract.SetActive(isOn));
    }
}
