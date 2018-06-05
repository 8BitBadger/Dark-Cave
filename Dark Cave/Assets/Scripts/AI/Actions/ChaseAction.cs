using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    Vector2 normalizedDir;

    public override void Act(StateController controller)
    {
        controller.randomWanderPoint = Vector2.zero;

        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        normalizedDir = (new Vector2(controller.chaseTarget.position.x, controller.chaseTarget.position.y) - controller.rb2d.position).normalized;
            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.walkSpeed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.walkSpeed, 0.8f));
    }
}