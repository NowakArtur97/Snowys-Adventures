using System.Collections.Generic;

public class JumpState : AbilityState
{
    public JumpState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void Enter()
    {
        base.Enter();

        Player.CoreContainer.Movement.SetVelocityY(Player.JumpVelocity);

        Player.CoreContainer.Animation.SetYVelocityVariable(Player.CoreContainer.Movement.CurrentVelocity.y);

        Player.CoreContainer.Sound.PlayJumpSound();

        IsAbilityFinished = true;
    }
}
