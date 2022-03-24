using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private readonly string DISSAPEAR_TRIGGER = "dissapear";

    private WinManager _winManager;
    private Animator _animator;
    private bool _wasFound;

    private void Awake()
    {
        _winManager = FindObjectOfType<WinManager>();
        _animator = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_wasFound)
        {
            AnimateTrigger();
            _winManager.FindFish();
            _wasFound = true;
        }
    }

    private void AnimateTrigger() => _animator.SetTrigger(DISSAPEAR_TRIGGER);
}
