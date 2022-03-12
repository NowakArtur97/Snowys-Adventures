using System.Collections.Generic;

public abstract class GroundedState : State
{
    protected bool IsGrounded { get; private set; }

    public GroundedState(Player entity, List<string> animationBoolNames) : base(entity, animationBoolNames) { }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
    }
}
