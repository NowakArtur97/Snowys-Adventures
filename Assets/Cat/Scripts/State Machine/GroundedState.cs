using System.Collections.Generic;

public abstract class GroundedState : State
{
    protected bool IsGrounded { get; private set; }
    protected float XMovementInput { get; private set; }
    protected bool JumpInput { get; private set; }

    public GroundedState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        XMovementInput = Player.CoreContainer.Input.MovementInput.x;
        JumpInput = Player.CoreContainer.Input.JumpInput;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
    }
}