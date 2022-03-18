using System.Collections.Generic;

public class LandState : GroundedState
{
    public LandState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void Enter()
    {
        base.Enter();

        Player.CoreContainer.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState && IsAnimationFinished)
        {
            Player.StateMachine.ChangeState(Player.IdleState);
        }
    }
}
