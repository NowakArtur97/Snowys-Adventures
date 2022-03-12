using System.Collections.Generic;

public class MoveState : GroundedState
{
    private float _xMovementInput;

    public MoveState(Player entity, List<string> animationBoolNames) : base(entity, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _xMovementInput = Player.CoreContainer.Input.Movement.x;

        Player.CoreContainer.Movement.CheckIfShouldFlip((int)_xMovementInput);
        Player.CoreContainer.Movement.SetVelocityX(Player.MoveVelocity * _xMovementInput);

        if (!IsExitingState)
        {
            if (_xMovementInput == 0)
            {
                Player.StateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}
