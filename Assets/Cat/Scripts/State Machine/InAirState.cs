using System.Collections.Generic;
using UnityEngine;

public class InAirState : State
{
    protected bool IsGrounded { get; private set; }
    protected float XMovementInput { get; private set; }
    protected bool JumpInput { get; private set; }

    public InAirState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        XMovementInput = Player.CoreContainer.Input.MovementInput.x;
        JumpInput = Player.CoreContainer.Input.JumpInput;

        Player.CoreContainer.Movement.CheckIfShouldFlip((int)Player.CoreContainer.Input.MovementInput.x);
        Player.CoreContainer.Movement.SetVelocityX(Player.InAirMoveVelocity * XMovementInput);
        Player.CoreContainer.Animation.SetYVelocityVariable(Player.CoreContainer.Movement.CurrentVelocity.y);
        Debug.Log(Player.CoreContainer.Movement.CurrentVelocity.y);

        if (!IsExitingState && IsGrounded)
        {
            if (JumpInput)
            {
                Player.StateMachine.ChangeState(Player.JumpState);
            }
            else if (Player.CoreContainer.Movement.CurrentVelocity.y < 0.01f)
            {
                Player.StateMachine.ChangeState(Player.LandState);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
    }
}
