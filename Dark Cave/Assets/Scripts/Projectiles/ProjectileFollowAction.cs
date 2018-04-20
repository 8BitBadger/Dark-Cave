using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/FollowTarget")]
public class FollowTargetAction : ProjectileAction
{
    public override void DoAction(ProjectileStats stats)
    {
        //TODO: find a better way to remove or reduce angular drag, angular drag due to the player bumping into the ai
        // if(controller.rb2d.angularVelocity > 0)
        // {
        //     controller.rb2d.angularVelocity = 0;
        // }
        
        Vector2 dir = new Vector2(controller.chaseTarget.position.x, controller.chaseTarget.position.y) - controller.rb2d.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, controller.transform.up).z;
        controller.rb2d.angularVelocity = -rotateAmount * controller.stats.rotateSpeed;

        FollowTarget(stats);
    }

    private void FollowTarget(ProjectileStats stats)
    {
        if ((Time.time - spawnTime) >= projectileStats.projectileLife)
        //if ((Time.time - projectileStats.spawnTime) >= projectileStats.projectileLife)
        {
            Destroy(gameObject);
        }

        if(projectileStats.hasDelaydEffect && (Time.time - spawnTime) >= projectileStats.delayEffectTimerTrigger)
        //if (projectileStats.hasDelaydEffect && (Time.time - projectileStats.spawnTime) >= projectileStats.delayEffectTimerTrigger)
        {
            projectileStats.followTarget = true;
        }
        
        Vector2 dir = new Vector2(target.position.x, target.position.y) - rb2d.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, transform.up).z;

        if (projectileStats.followTarget)
        {
            rb2d.angularVelocity = -rotateAmount * projectileStats.rotateSpeed;
            rb2d.velocity = dir * projectileStats.speed;
        }
        else
        {
            rb2d.velocity = staticDir * projectileStats.speed;
        }

    }
}