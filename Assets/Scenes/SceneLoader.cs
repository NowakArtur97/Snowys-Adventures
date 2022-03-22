using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public bool _shouldPlayStartAnimation = true;

    private readonly string START_LEVEL_TRIGGER = "start";
    private readonly string END_LEVEL_TRIGGER = "end";
    private Animator _myAnimator;

    private void Awake()
    {
        _myAnimator = GetComponent<Animator>();

        if (_shouldPlayStartAnimation)
        {
            _myAnimator.SetTrigger(START_LEVEL_TRIGGER);
        }
    }

    public void StartEndLevelTransition() => _myAnimator.SetTrigger(END_LEVEL_TRIGGER);

    public void TransitionOverTrigger() => LevelManager.LoadNextScene();
}
