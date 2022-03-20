using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampLight : MonoBehaviour
{
    [SerializeField] private float _intensityOn = 0.7f;
    [SerializeField] private float _intensityOff = 0f;

    private Light2D _myLight2d;

    private void Awake() => _myLight2d = GetComponent<Light2D>();

    public void ChangeIntensity(bool isOn) => _myLight2d.intensity = isOn ? _intensityOn : _intensityOff;
}
