using System.Collections.Generic;
using System.Linq;

public class PlugOutState : AbilityState
{
    public PlugOutState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState && IsAnimationFinished)
        {
            IsAbilityFinished = true;
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        Player.CoreContainer.CollisionSenses.ClosePlugableOut
            .ToList()
            .ForEach(plugable => plugable.gameObject.GetComponentInParent<ElectricDevice>().Interact());
    }
}