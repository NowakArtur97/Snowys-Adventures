using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected readonly Player Player;

    protected bool IsExitingState { get; private set; }
    protected bool IsAnimationFinished { get; private set; }

    private List<string> _animationBoolNames;
    private string _animationBoolName;

    public State(Player player, List<string> animationBoolNames)
    {
        Player = player;
        _animationBoolNames = animationBoolNames;
    }

    public virtual void Enter()
    {
        IsExitingState = false;
        IsAnimationFinished = false;

        //Player.CoreContainer.AnimationToStateMachine.CurrentState = this;

        _animationBoolName = GetRandomAnimation();
        Debug.Log(_animationBoolName);
        Player.CoreContainer.Animation.SetBoolVariable(_animationBoolName, true);

        DoChecks();
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() => DoChecks();

    public virtual void Exit()
    {
        Player.CoreContainer.Animation.SetBoolVariable(_animationBoolName, false);

        IsExitingState = true;
    }

    public virtual void DoChecks() { }

    public virtual void AnimationFinishedTrigger() => IsAnimationFinished = true;
    public virtual void AnimationTrigger() { }

    private string GetRandomAnimation() => _animationBoolNames[Random.Range(0, _animationBoolNames.Count)];
}
