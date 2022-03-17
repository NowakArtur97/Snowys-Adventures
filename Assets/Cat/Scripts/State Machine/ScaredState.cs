using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScaredState : State
{
    public ScaredState(Player player, List<string> animationBoolNames) : base(player, animationBoolNames) { }

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
            // TODO: ScaredState: Show restart UI
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
