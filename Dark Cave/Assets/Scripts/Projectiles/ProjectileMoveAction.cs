using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/Move")]
public class ProjectileMoveAction : ProjectileAction
{
    private Vector2 staticDir;
    private bool initDone;
    public int moveSpeed;

    private void Init(Projectile projectile)
    {
        staticDir = new Vector2(projectile.Target.position.x, projectile.Target.position.y) - projectile.Rb2d.position;
        staticDir.Normalize();
        projectile.Rb2d.MoveRotation(Vector3.Cross(staticDir, projectile.Rb2d.transform.up).z);
    }

    public override void DoAction(Projectile projectile)
    {
        if(!initDone)
        {
            Init(projectile);
            initDone = true;
        }
        Move(projectile);
    }

    private void Move(Projectile projectile)
    {      
        projectile.Rb2d.velocity = staticDir * moveSpeed * Time.deltaTime;
    }
}