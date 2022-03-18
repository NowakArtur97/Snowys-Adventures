using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private WinManager _winManager;
    private bool _wasFound;

    private void Awake() => _winManager = FindObjectOfType<WinManager>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_wasFound)
        {
            _winManager.FindFish();
            _wasFound = true;
        }
    }
}
