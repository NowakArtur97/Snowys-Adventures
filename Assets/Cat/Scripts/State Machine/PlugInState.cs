using System.Collections.Generic;
using System.Linq;

public class PlugInState : AbilityState
{
    public PlugInState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

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

        Player.CoreContainer.CollisionSenses.ClosePlugableIn
            .ToList()
            .ForEach(plugable => plugable.gameObject.GetComponentInParent<ElectricDevice>().Interact());
    }
}
