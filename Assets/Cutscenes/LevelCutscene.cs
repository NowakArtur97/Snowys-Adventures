using UnityEngine;
using UnityEngine.Playables;

public class LevelCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] Transform _cutscenePosition;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        _playableDirector.Play();

        collision.gameObject.transform.position = _cutscenePosition.position;
    }
}
