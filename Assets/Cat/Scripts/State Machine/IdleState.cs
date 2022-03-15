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
            if (JumpInput)
            {
                Player.StateMachine.ChangeState(Player.JumpState);
            }
            else if (Player.CoreContainer.Input.MovementInput.x != 0)
            {
                Player.StateMachine.ChangeState(Player.MoveState);
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
