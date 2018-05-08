using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Move To Last Seen Point")]
public class MoveToPointAction : Action
{
    public override void Act(StateController controller)
    {
        MoveToPoint(controller);
    }

    private void MoveToPoint(StateController controller)
    {
            Vector2 dir = controller.lastSeenPoint - controller.rb2d.position;

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
