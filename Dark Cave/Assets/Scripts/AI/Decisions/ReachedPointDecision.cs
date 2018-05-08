using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Reached Point")]
public class ReachedPointDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return ReachedPoint(controller);
    }

    private bool ReachedPoint(StateController controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.lastSeenPoint) < 0.4f)
        {
            return true;
        }

        return false;
    }
}
