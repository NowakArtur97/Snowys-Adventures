using System.Collections.Generic;

public abstract class AbilityState : State
{
    protected bool IsAbilityFinished;
    protected bool IsGrounded { get; private set; }

    public AbilityState(Player entity, List<string> animationBoolNames) : base(entity, animationBoolNames) { }

    public override void Enter()
    {
        base.Enter();

        IsAbilityFinished = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState && IsAbilityFinished)
        {
            if (IsGrounded && Player.CoreContainer.Movement.CurrentVelocity.y < 0.01)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
            else if (!IsGrounded)
            {
                Player.StateMachine.ChangeState(Player.InAirState);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
    }
}
