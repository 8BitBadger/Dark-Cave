using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Run")]
public class RunAction : Action
{
    Vector2 normalizedDir;

    public override void Act(StateController controller)
    {
        controller.Speed(controller.stats.sprintSpeed);
        Run(controller);
    }

    private void Run(StateController controller)
    {
        normalizedDir = (new Vector2(controller.chaseTarget.position.x, controller.chaseTarget.position.y) - controller.rb2d.position).normalized;

        controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.speed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.speed, 0.8f));
    }
}