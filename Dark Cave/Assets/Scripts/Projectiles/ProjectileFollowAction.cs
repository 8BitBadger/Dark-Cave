using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/FollowTarget")]
public class FollowTargetAction : ProjectileAction
{
    public override void DoAction(ProjectileStats stats)
    {
        FollowTarget(stats);
    }

    private void FollowTarget(ProjectileStats stats)
    {     
        Vector2 dir = new Vector2(stats.Target.position.x, stats.Target.position.y) - stats.Rb2d.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, stats.transform.up).z;

        rb2d.angularVelocity = rotateAmount * (stats.rotateSpeed * Time.deltaTime);
        rb2d.velocity = dir * (stats.speed * Time.deltaTime);
    }
}