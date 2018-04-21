using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Projectile/Actions/Split")]
public class SplitAction : ProjectileAction
{
    public List<GameObjects> childProjectiles;
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