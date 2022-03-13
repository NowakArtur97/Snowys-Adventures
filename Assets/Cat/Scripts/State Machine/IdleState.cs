using System.Collections.Generic;

public class IdleState : GroundedState
{
    public IdleState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

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
            if (Player.CoreContainer.Input.JumpInput)
            {
                Player.StateMachine.ChangeState(Player.JumpState);
            }
            else if (Player.CoreContainer.Input.MovementInput.x != 0)
            {
                Player.StateMachine.ChangeState(Player.MoveState);
            }
        }
    }
}
