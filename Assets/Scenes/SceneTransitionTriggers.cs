using UnityEngine;

public class SceneTransitionTriggers : MonoBehaviour
{
    private Input _input;

    private void Start() => _input = FindObjectOfType<Input>();

    public void StartLevelTrigger() => _input.EnableMovemnt();

    public void EndLevelTrigger() => LevelManager.LoadNextScene();
}
