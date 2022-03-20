using UnityEngine;

public class Phone : MonoBehaviour
{
    private ElectricDevice _electricDevice;

    private void Awake() => _electricDevice = transform.parent.GetComponentInChildren<ElectricDevice>();

    private void OnTriggerEnter2D(Collider2D collision) => _electricDevice.Interact();
}
