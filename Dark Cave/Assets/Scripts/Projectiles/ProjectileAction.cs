using UnityEngine;

namespace ProjectileLogic
{
    public abstract class ProjectileAction : ScriptableObject
    {
        public float delayedEffectTimerTrigger;
        public abstract void DoAction(Projectile projectile);
    }
}