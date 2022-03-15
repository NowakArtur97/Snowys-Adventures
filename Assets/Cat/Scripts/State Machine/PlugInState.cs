using System.Collections.Generic;
using UnityEngine;

public class PlugInState : AbilityState
{
    public PlugInState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void Enter()
    {
        base.Enter();

        Player.CoreContainer.Movement.SetVelocityZero();

        Collider2D[] plugableInClose = Player.CoreContainer.CollisionSenses.ClosePlugableIn;

        Debug.Log(plugableInClose.Length);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState && IsAnimationFinished)
        {
            IsAbilityFinished = true;
        }
    }
}
