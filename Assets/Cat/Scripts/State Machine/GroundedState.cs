using System.Collections.Generic;

public abstract class GroundedState : State
{
    protected bool IsGrounded { get; private set; }
    protected bool IsPlugablInClose { get; private set; }
    protected bool IsPlugablOutClose { get; private set; }
    protected float XMovementInput { get; private set; }
    protected bool JumpInput { get; private set; }
    protected bool InteractInput { get; private set; }

    public GroundedState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        XMovementInput = Player.CoreContainer.Input.MovementInput.x;
        JumpInput = Player.CoreContainer.Input.JumpInput;
        InteractInput = Player.CoreContainer.Input.InteractInput;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
        IsPlugablInClose = Player.CoreContainer.CollisionSenses.IsPlugablInClose;
        IsPlugablOutClose = Player.CoreContainer.CollisionSenses.IsPlugablOutClose;
    }
}