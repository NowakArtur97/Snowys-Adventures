using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private readonly string END_LEVEL_TRIGGER = "end";
    private Animator _myAnimator;

    private void Awake() => _myAnimator = GetComponent<Animator>();

    public void StartEndLevelTransition() => _myAnimator.SetTrigger(END_LEVEL_TRIGGER);

    public void TransitionOverTrigger() => LevelManager.LoadNextScene();
}
