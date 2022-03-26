using System.Collections.Generic;
using static CameraShake;

public class LandState : GroundedState
{
    public LandState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void Enter()
    {
        base.Enter();

        Player.CoreContainer.Movement.SetVelocityZero();

        CameraShakeInstance.Shake();

        Player.CoreContainer.Sound.PlayLandSound();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState && IsAnimationFinished)
        {
            Player.StateMachine.ChangeState(Player.IdleState);
        }
    }
}
