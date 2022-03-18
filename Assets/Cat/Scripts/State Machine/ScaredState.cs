using System.Collections.Generic;

public class ScaredState : State
{
    public ScaredState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    private bool _isGrounded;

    public override void Enter()
    {
        base.Enter();

        Player.CoreContainer.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState && IsAnimationFinished)
        {
            Player.CalmDown();

            if (Player.IsTerrified)
            {
                // TODO: ScaredState: Show restart UI
                LevelManager.ReloadScene();
            }
            else if (_isGrounded && Player.CoreContainer.Movement.CurrentVelocity.y < 0.01)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
            else if (!_isGrounded)
            {
                Player.StateMachine.ChangeState(Player.InAirState);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
    }
}
