using System.Collections.Generic;

public class MoveState : GroundedState
{
    public MoveState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void Exit()
    {
        base.Exit();

        Player.CoreContainer.Sound.StopPlayingSounds();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Player.CoreContainer.Movement.CheckIfShouldFlip((int)XMovementInput);
        Player.CoreContainer.Movement.SetVelocityX(Player.MoveVelocity * XMovementInput);
        Player.CoreContainer.Sound.PlayMoveSound();

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
            else if (InteractInput)
            {
                Player.CoreContainer.Input.UseInteractInput();

                if (IsPlugablInClose)
                {
                    Player.StateMachine.ChangeState(Player.PlugInState);
                }
                else if (IsPlugablOutClose)
                {
                    Player.StateMachine.ChangeState(Player.PlugOutState);
                }
            }
        }
    }
}
