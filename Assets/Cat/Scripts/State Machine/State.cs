using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected readonly Player Player;

    protected bool IsExitingState { get; private set; }
    protected bool IsAnimationFinished { get; private set; }
    protected float StateStartTime { get; private set; }

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
        StateStartTime = Time.time;

        Player.CoreContainer.AnimationToStateMachine.CurrentState = this;

        _animationBoolName = GetRandomAnimation();
        Player.CoreContainer.Animation.SetBoolVariable(_animationBoolName, true);

        DoChecks();
    }

    public virtual void LogicUpdate()
    {
        if ((Player.IsScared || Player.IsTerrified) && Player.StateMachine.CurrentState != Player.ScaredState)
        {
            Player.StateMachine.ChangeState(Player.ScaredState);
        }

        if (Player.CoreContainer.Input.RestartLevelInput)
        {
            LevelManager.ReloadScene();
        }
    }

    public virtual void PhysicsUpdate() => DoChecks();

    public virtual void Exit()
    {
        Player.CoreContainer.Animation.SetBoolVariable(_animationBoolName, false);

        IsExitingState = true;
    }

    public virtual void DoChecks() { }

    public void AnimationFinishedTrigger() => IsAnimationFinished = true;

    public virtual void AnimationTrigger() { }

    private string GetRandomAnimation() => _animationBoolNames[Random.Range(0, _animationBoolNames.Count)];
}
