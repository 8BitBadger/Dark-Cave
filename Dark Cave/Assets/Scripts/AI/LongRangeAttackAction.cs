using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Long Range Attack")]
public class LongRangeAttackAction : Action
{
    public GameObject projectile;

    public override void Act(StateController controller)
    {
        //TODO: find a better way to remove or reduce angular drag, angular drag due to the player bumping into the ai
        if (controller.rb2d.angularVelocity > 0)
        {
            controller.rb2d.angularVelocity = 0;
        }
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        if ((Time.time - controller.timeSinceLastAttack) > controller.stats.attackInterval)
        {
            GameObject tempProjectile = Instantiate(projectile, controller.transform.position, Quaternion.identity);
            
            Projectile tempMovement = tempProjectile.GetComponent<Projectile>();

            Physics2D.IgnoreCollision(tempProjectile.GetComponent<Rigidbody2D>().GetComponent<Collider2D>(), controller.GetComponent<Collider2D>());

            tempMovement.Target = controller.chaseTarget.transform;
            
            controller.timeSinceLastAttack = Time.time;
        }
    }
}