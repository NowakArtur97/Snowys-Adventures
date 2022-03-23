using UnityEngine;

public class PlugOutPosition : MonoBehaviour
{
    [SerializeField] private float _offsetY = 0.32f;
    [SerializeField] private Transform _electricalContactPosition;

    private void Start() => transform.position = new Vector2(_electricalContactPosition.position.x,
        _electricalContactPosition.position.y - _offsetY);
}
