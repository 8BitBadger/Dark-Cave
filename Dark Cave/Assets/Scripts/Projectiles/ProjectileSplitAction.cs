using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/Split")]
public class SplitAction : ProjectileAction
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

        Split(stats);
    }

    private void Split(ProjectileStats stats)
    {
        if((Time.time - controller.timeSinceLastAttack) > controller.stats.attackInterval )
        {
            controller.chaseTarget.gameObject.GetComponent<Player>().TakeDamage(controller.stats.baseDamage);
            controller.timeSinceLastAttack = Time.time;
        }
    }
}