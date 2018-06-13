using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Look(controller);
    }

    private bool Look(StateController controller)
    {
        //Cast a collision circle only in the raduised area and on the target target mask, this is to check if the target is in the raduis to be able to pick it up
        Collider2D[] targetInViewRaduis = Physics2D.OverlapCircleAll(controller.rb2d.position, controller.stats.viewRadius, controller.stats.targetLayer);

        //Loop through the targets that are in range of the fow
        for (int i = 0; i < targetInViewRaduis.Length; i++)
        {
            Transform rayCastTarget = targetInViewRaduis[i].transform;
            Vector2 dirToRaycast = (rayCastTarget.position - controller.transform.position).normalized;

            if (Vector2.Angle(controller.transform.right, dirToRaycast) < controller.stats.viewAngle / 2)
            {
                float distanceToTarget = Vector2.Distance(controller.transform.position, rayCastTarget.position);

                if (!Physics2D.Raycast(controller.rb2d.position, dirToRaycast, distanceToTarget, controller.stats.obstacleMask))
                {
                    controller.chaseTarget = rayCastTarget;
                    controller.lastSeenPoint = controller.chaseTarget.position;

                    return true;
                }
            }
        }
        return false;
    }
}