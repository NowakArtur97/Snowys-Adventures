using System.Collections.Generic;
using UnityEngine;

public class InAirState : State
{
    private readonly float WAIT_FOR_JUMP_TIME = 1f;

    private bool _isGrounded;
    private Vector2 _currentVelocity;
    private float _xMovementInput;
    private bool _jumpInput;

    public InAirState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _xMovementInput = Player.CoreContainer.Input.MovementInput.x;
        _jumpInput = Player.CoreContainer.Input.JumpInput;
        _currentVelocity = Player.CoreContainer.Movement.CurrentVelocity;

        Player.CoreContainer.Movement.CheckIfShouldFlip((int)Player.CoreContainer.Input.MovementInput.x);
        Player.CoreContainer.Movement.SetVelocityX(Player.MoveVelocity * _xMovementInput);
        Player.CoreContainer.Animation.SetYVelocityVariable(_currentVelocity.y);

        if (!IsExitingState)
        {
            if (_isGrounded && _jumpInput)
            {
                Player.StateMachine.ChangeState(Player.JumpState);
            }
            else if (_isGrounded && _currentVelocity.y < 0.01f && !_jumpInput)
            {
                Player.StateMachine.ChangeState(Player.LandState);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = Player.CoreContainer.CollisionSenses.IsGrounded;
    }
}
