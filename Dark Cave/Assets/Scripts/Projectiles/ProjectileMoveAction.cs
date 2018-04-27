using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/Move")]
public class FollowMoveAction : ProjectileAction
{
    private Vector2 staticDir;
    private bool initDone = false;

    private void Init(ProjectileStats stats)
    {
        staticDir = new Vector2(stats.Target.position.x, stats.Target.position.y) - stats.Rb2d.position;
        staticDir.Normalize();
    }

    public override void DoAction(ProjectileStats stats)
    {
        if(!initDone)
        {
            Init(stats);
            initDone = true;
        }

        Move(stats);
    }

    private void Move(ProjectileStats stats)
    {      
        stats.Rb2d.velocity = staticDir * stats.speed * Time.deltaTime;
    }
}