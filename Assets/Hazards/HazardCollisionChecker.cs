using UnityEngine;

public class HazardCollisionChecker : MonoBehaviour
{
    private FearLevelManager _fearLevelManager;
    private Player _player;

    private void Awake()
    {
        _fearLevelManager = FindObjectOfType<FearLevelManager>();

        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _fearLevelManager.IncreaseFearLevel();

        _player.Scare();
    }
}
