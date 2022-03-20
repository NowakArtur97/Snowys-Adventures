using UnityEngine;
using static ElectricDevice;

public class HazardCollisionChecker : MonoBehaviour
{
    private ElectricDevice electricDevice;
    private FearLevelManager _fearLevelManager;
    private Player _player;

    private void Awake()
    {
        electricDevice = GetComponent<ElectricDevice>();

        _fearLevelManager = FindObjectOfType<FearLevelManager>();

        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (electricDevice.CurrentState == ElectricDeviceState.ON)
        {
            _fearLevelManager.IncreaseFearLevel();

            _player.Scare();
        }
    }
}
