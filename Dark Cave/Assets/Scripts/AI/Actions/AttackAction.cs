using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
       //TODO: Make it so sprite is showing in the general direction of the player

        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        if((Time.time - controller.timeSinceLastAttack) > controller.stats.attackInterval )
        {
            controller.chaseTarget.gameObject.GetComponent<Player>().TakeDamage(controller.stats.baseDamage);
            controller.timeSinceLastAttack = Time.time;
        }
    }
}