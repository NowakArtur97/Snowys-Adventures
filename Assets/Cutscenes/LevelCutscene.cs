using UnityEngine;
using UnityEngine.Playables;

public class LevelCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] Transform _cutscenePosition;

    private Input _input;
    private Sound _sound;

    private void Start()
    {
        _input = FindObjectOfType<Input>();
        _sound = FindObjectOfType<Sound>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        StopPlayerActions();

        _playableDirector.Play();

        collision.gameObject.transform.position = _cutscenePosition.position;
    }

    private void StopPlayerActions()
    {
        _input.DisableMovemnt();

        _sound.StopPlayingSounds();
    }
}
