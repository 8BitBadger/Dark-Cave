using UnityEngine;

namespace ProjectileLogic
{
    [CreateAssetMenu(menuName = "Projectile/Actions/Move")]
    public class ProjectileMoveAction : ProjectileAction
    {
        private Vector2 staticDir;
        private bool initDone = false;
        public int moveSpeed;

        private void Init(Projectile projectile)
        {
            staticDir = new Vector2(projectile.Target.position.x, projectile.Target.position.y) - projectile.Rb2d.position;
            projectile.Rb2d.MoveRotation(Mathf.Atan2(staticDir.y, staticDir.x) * Mathf.Rad2Deg);
        }

        public override void DoAction(Projectile projectile)
        {
            if (initDone == false)
            {
                Init(projectile);
                initDone = true;
            }
            Move(projectile);
        }

        private void Move(Projectile projectile)
        {

            projectile.Rb2d.velocity = new Vector2(staticDir.x + moveSpeed * Time.deltaTime, staticDir.y + moveSpeed * Time.deltaTime);
        }
    }
}