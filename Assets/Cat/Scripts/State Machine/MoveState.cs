using System.Collections.Generic;

public class MoveState : GroundedState
{
    public MoveState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Player.CoreContainer.Movement.CheckIfShouldFlip((int)XMovementInput);
        Player.CoreContainer.Movement.SetVelocityX(Player.MoveVelocity * XMovementInput);

        if (!IsExitingState)
        {
            if (JumpInput)
            {
                Player.StateMachine.ChangeState(Player.JumpState);
            }
            else if (!IsGrounded)
            {
                Player.StateMachine.ChangeState(Player.InAirState);
            }
            else if (XMovementInput == 0)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}
