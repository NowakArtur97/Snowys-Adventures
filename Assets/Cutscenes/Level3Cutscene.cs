using UnityEngine;
using UnityEngine.Playables;

public class Level3Cutscene : MonoBehaviour
{
    [SerializeField] Transform _cutscenePosition;
    [SerializeField] private ElectricDevice _electricDevice;
    [SerializeField] private PlayableDirector _playableDirector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = _cutscenePosition.position;

        _electricDevice.Interact();

        _playableDirector.Play();

        gameObject.SetActive(false);
    }
}
