using UnityEngine;

public class LightChecker : MonoBehaviour
{
    private PolygonCollider2D _myPolygonCollider2D;

    private void Awake()
    {
        _myPolygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
