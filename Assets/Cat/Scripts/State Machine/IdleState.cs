using System.Collections.Generic;

public class IdleState : GroundedState
{
    public IdleState(Player entity, List<string> animationBoolNames) : base(entity, animationBoolNames) { }

    public override void Enter()
    {
        base.Enter();

        Player.CoreContainer.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState)
        {
            if (Player.CoreContainer.Input.Movement.x != 0)
            {
                Player.StateMachine.ChangeState(Player.MoveState);
            }
        }
    }
}
