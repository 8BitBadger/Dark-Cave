using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Attack")]
public class AttackDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Attack(controller);
    }

    private bool Attack(StateController controller)
    {
        if (Vector2.Distance(controller.chaseTarget.position, controller.rb2d.position) <= controller.stats.attackRange)
        {
            controller.rb2d.velocity = Vector2.zero;
            return true;
        }

        return false;
    }
}