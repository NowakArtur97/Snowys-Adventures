using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampLight : MonoBehaviour
{
    [SerializeField] private float _intensityOn = 0.7f;
    [SerializeField] private float _intensityOff = 0f;
    [SerializeField] private float _timeToChangeIntensity = 0.5f;

    private Light2D _myLight2d;
    private float _currentIntensity;
    private float _lerpDuration;
    private float _timeElapsed;
    private bool _isOn;

    private void Awake() => _myLight2d = GetComponent<Light2D>();

    private void Update()
    {
        if (_timeElapsed < _lerpDuration)
        {
            if (_isOn)
            {
                LerpIntensity(_intensityOn);
            }
            else
            {
                LerpIntensity(_intensityOff);
            }
        }
    }

    private void LerpIntensity(float maxValue)
    {
        _myLight2d.intensity = Mathf.Lerp(_currentIntensity, maxValue, _timeElapsed / _lerpDuration);
        _timeElapsed += Time.deltaTime;
    }

    public void ChangeIntensity(bool isOn)
    {
        _isOn = isOn;
        _currentIntensity = isOn ? _intensityOff : _intensityOn;
        _lerpDuration = Time.deltaTime + _timeToChangeIntensity;
        _timeElapsed = Time.deltaTime;
    }
}
