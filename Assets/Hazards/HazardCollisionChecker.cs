using UnityEngine;

public class HazardCollisionChecker : MonoBehaviour
{
    private FearLevelManager _fearLevelManager;

    private void Awake() => _fearLevelManager = FindObjectOfType<FearLevelManager>();

    private void OnTriggerEnter2D(Collider2D collision) => _fearLevelManager.Scare();
}
