using UnityEngine;

public class OutroScene : MonoBehaviour
{
    private Input _input;

    private void Awake() => _input = FindObjectOfType<Input>();

    private void Update()
    {
        if (_input.JumpInput)
        {
            FindObjectOfType<SceneLoader>().StartEndLevelTransition();
        }
    }
}
