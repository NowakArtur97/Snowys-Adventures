using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation : MonoBehaviour
{
    private readonly string Y_VELOCITY = "yVelocity";

    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    public void SetBoolVariable(string animationBoolName, bool value) => _animator.SetBool(animationBoolName, value);

    public void SetVelocityVariable(float xVelocity) => _animator.SetFloat(Y_VELOCITY, xVelocity);
}
