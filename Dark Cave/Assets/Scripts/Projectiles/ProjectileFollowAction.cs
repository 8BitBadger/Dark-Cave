using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/FollowTarget")]
public class ProjectileFollowAction : ProjectileAction
{
    public int moveSpeed;
    public int rotateSpeed;

    public override void DoAction(Projectile projectile)
    {
        FollowTarget(projectile);
    }

    private void FollowTarget(Projectile projectile)
    {     
        Vector2 dir = new Vector2(projectile.Target.position.x, projectile.Target.position.y) - projectile.Rb2d.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, projectile.Rb2d.transform.up).z;

        projectile.Rb2d.angularVelocity = rotateAmount * (rotateSpeed * Time.deltaTime);
        projectile.Rb2d.velocity = dir * (moveSpeed * Time.deltaTime);
    }
}