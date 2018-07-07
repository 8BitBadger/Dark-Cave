using System.Collections.Generic;
using UnityEngine;

namespace ProjectileLogic
{
    [CreateAssetMenu(menuName = "Projectile/Actions/Split")]
    public class ProjectileSplitAction : ProjectileAction
    {
        public List<GameObject> childProjectiles;
        public int amountOfCopies;

        public override void DoAction(Projectile projectile)
        {
            Split(projectile);
        }

        private void Split(Projectile projectile)
        {
            //TODO: Instantiate the amount of copies of the child object that is needed
        }
    }
}
