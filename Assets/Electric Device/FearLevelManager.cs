using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FearLevelManager : MonoBehaviour
{
    [SerializeField] private float _fearStep = 0.05f;
    [SerializeField] private float _timeBetweenFearSteps = 1.0f;
    [SerializeField] private Scrollbar _fearLevelScrollbar;
    [SerializeField] private GameObject _fearLevelScrollbarHandle;

    private float _levelOfFear;
    private int _numberOfLights;
    private bool _isOutsideTheLight;
    private bool _isInCoroutine;

    private void Awake() => _fearLevelScrollbarHandle.SetActive(false);

    private void Start()
    {
        if (IsPlayerInDarkness())
        {
            _isOutsideTheLight = true;
        }
    }

    private void Update()
    {
        if (_isOutsideTheLight && !_isInCoroutine)
        {
            StartCoroutine(ScaredCoroutine());
        }
    }

    public void RegistrerLight()
    {
        _numberOfLights++;
        _isOutsideTheLight = false;
    }

    public void UnregistrerLight()
    {
        _numberOfLights--;

        if (IsPlayerInDarkness())
        {
            _isOutsideTheLight = true;
        }
    }

    private IEnumerator ScaredCoroutine()
    {
        _isInCoroutine = true;

        yield return new WaitForSeconds(_timeBetweenFearSteps);

        if (_isOutsideTheLight)
        {
            IncreaseFearLevel();
        }

        _isInCoroutine = false;
    }

    public void IncreaseFearLevel()
    {
        if (!_fearLevelScrollbarHandle.activeInHierarchy)
        {
            _fearLevelScrollbarHandle.SetActive(true);
        }

        _levelOfFear += _fearStep;
        _fearLevelScrollbar.size = _levelOfFear;

        if (IsFearLevelMax())
        {
            FindObjectOfType<Player>().Terrify();
        }
    }

    private bool IsPlayerInDarkness() => _numberOfLights == 0;

    private bool IsFearLevelMax() => _fearLevelScrollbar.size >= 1;
}
