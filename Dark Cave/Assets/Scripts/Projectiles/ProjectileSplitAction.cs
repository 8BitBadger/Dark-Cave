using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(menuName = "Projectile/Actions/Split")]
//public class SplitAction : ProjectileAction
//{
//    public override void DoAction(ProjectileStats stats)
//    {
//        //TODO: find a better way to remove or reduce angular drag, angular drag due to the player bumping into the ai
//        // if(controller.rb2d.angularVelocity > 0)
//        // {
//        //     controller.rb2d.angularVelocity = 0;
//        // }

//        Vector2 dir = new Vector2(stats.chaseTarget.position.x, stats.chaseTarget.position.y) - stats.rb2d.position;
//        dir.Normalize();
//        float rotateAmount = Vector3.Cross(dir, stats.transform.up).z;
//        controller.rb2d.angularVelocity = -rotateAmount * stats.stats.rotateSpeed;

//        Split(stats);
//    }

//    private void Split(ProjectileStats stats)
//    {
//        if ((Time.time - controller.timeSinceLastAttack) > controller.stats.attackInterval)
//        {
//            controller.chaseTarget.gameObject.GetComponent<Player>().TakeDamage(controller.stats.baseDamage);
//            controller.timeSinceLastAttack = Time.time;
//        }
//    }
//}

[CreateAssetMenu(menuName = "Projectile/Actions/Split")]
public class SplitAction : ProjectileAction
{
    public List<GameObject> childProjectiles;
    public int amountOfCopies;

    public override void DoAction(ProjectileStats stats)
    {
        Split(stats);
    }

    private void Split(ProjectileStats stats)
    {
        //TODO: Instantiate the amount of copies of the child object that is needed
    }
}
