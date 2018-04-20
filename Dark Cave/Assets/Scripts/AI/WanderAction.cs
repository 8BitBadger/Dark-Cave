using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : Action
{
    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {
        if (Vector2.Distance(controller.rb2d.position, controller.randomWanderPoint) < 0.4f || controller.randomWanderPoint == Vector2.zero)
        {
            bool validPath = false;

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
            Vector2 dir = controller.randomWanderPoint - controller.rb2d.position;
            
            controller.rb2d.MoveRotation(Mathf.LerpAngle(controller.rb2d.rotation, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, .1f));

            if (Mathf.Abs(Vector3.Cross(dir.normalized, controller.transform.right).z) < .02f)
            {
                controller.stats.maxSpeed *= controller.stats.speedModifier;
                Vector2 normalizedDir = dir.normalized;
                if (controller.rb2d.velocity.x < controller.stats.maxSpeed)
                {
                    normalizedDir.x *= controller.stats.accel;
                }
                else
                {
                    normalizedDir.x = 0;
                }

                if (controller.rb2d.velocity.y < controller.stats.maxSpeed)
                {
                    normalizedDir.y *= controller.stats.accel;
                }
                else
                {
                    normalizedDir.y = 0;
                }

                controller.rb2d.AddForce(normalizedDir, ForceMode2D.Force);
            }
        }           

    }
}
