using UnityEngine;

public class ShakeInteraction : MonoBehaviour
{
    private readonly string INTERACT_LEFT_TRIGGER = "interactFromLeft";
    private readonly string INTERACT_RIGHT_TRIGGER = "interactFromRight";
    private Animator _myAnimator;

    private void Awake() => _myAnimator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D collision) => _myAnimator.SetTrigger(collision.gameObject.transform.position.x > transform.position.x
        ? INTERACT_RIGHT_TRIGGER : INTERACT_LEFT_TRIGGER);
}
