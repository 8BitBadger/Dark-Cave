using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Long Range Attack")]
public class LongRangeAttackAction : Action
{
    public GameObject projectile;

    public override void Act(StateController controller)
    {

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