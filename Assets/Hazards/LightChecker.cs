using UnityEngine;
using static ElectricDevice;

public class LightChecker : MonoBehaviour
{
    private PolygonCollider2D _myPolygonCollider2D;
    private ElectricDevice _electricDevice;
    private FearLevelManager _fearLevelManager;
    private bool _isInLight;

    private void Awake()
    {
        _myPolygonCollider2D = GetComponent<PolygonCollider2D>();
        _electricDevice = gameObject.transform.parent.GetComponentInChildren<ElectricDevice>();
        _fearLevelManager = FindObjectOfType<FearLevelManager>();

        _electricDevice.OnTurnOff += UnregisterLight;
    }

    private void OnDestroy() => _electricDevice.OnTurnOff -= UnregisterLight;

    private void UnregisterLight()
    {
        if (_isInLight)
        {
            LeaveLight();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_electricDevice.CurrentState == ElectricDeviceState.ON)
        {
            EnterLight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_electricDevice.CurrentState == ElectricDeviceState.ON)
        {
            LeaveLight();
        }
    }

    private void EnterLight()
    {
        _isInLight = true;
        _fearLevelManager.RegistrerLight();
    }

    private void LeaveLight()
    {
        _isInLight = false;
        _fearLevelManager.UnregistrerLight();
    }
}
