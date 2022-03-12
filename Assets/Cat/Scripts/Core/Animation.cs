using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation : MonoBehaviour
{
    private readonly string X_VELOCITY = "xVelocity";

    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    public void SetBoolVariable(string animationBoolName, bool value) => _animator.SetBool(animationBoolName, value);

    public void SetVelocityVariable(float xVelocity) => _animator.SetFloat(X_VELOCITY, xVelocity);
}
