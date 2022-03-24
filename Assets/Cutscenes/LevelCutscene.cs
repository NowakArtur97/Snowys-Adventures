using UnityEngine;
using UnityEngine.Playables;

public class LevelCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] Transform _cutscenePosition;

    private Input _input;

    private void Start() => _input = FindObjectOfType<Input>();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        _input.DisableMovemnt();

        _playableDirector.Play();

        collision.gameObject.transform.position = _cutscenePosition.position;
    }
}
