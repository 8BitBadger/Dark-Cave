using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : Action
{
    Vector2 normalizedDir;

    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.randomWanderPoint) < 0.4f || controller.randomWanderPoint == Vector2.zero)
        {
            bool validPath = false;

            normalizedDir = Vector2.zero;

            Vector2 newPatrolPoint;

            while (!validPath)
            {
                newPatrolPoint = new Vector2(Mathf.RoundToInt(Random.Range(-(controller.stats.wanderDistance + 1), controller.stats.wanderDistance) + controller.transform.position.x), Mathf.RoundToInt(Random.Range(-(controller.stats.wanderDistance + 1), controller.stats.wanderDistance) + controller.transform.position.y));

                if (!Physics2D.Linecast(controller.rb2d.position, newPatrolPoint, controller.stats.obstacleMask))
                {
                    validPath = true;
                    controller.randomWanderPoint = newPatrolPoint;
                }
            }

        }
        else
        {
            normalizedDir = (controller.randomWanderPoint - controller.rb2d.position).normalized;

            controller.rb2d.velocity = new Vector2(Mathf.Lerp(0, normalizedDir.x * controller.walkSpeed, 0.8f), Mathf.Lerp(0, normalizedDir.y * controller.walkSpeed, 0.8f));
        }
    }
}

