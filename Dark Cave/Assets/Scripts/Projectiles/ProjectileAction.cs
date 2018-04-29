using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileAction : ScriptableObject
{
    public float delayedEffectTimerTrigger;
    public abstract void DoAction(Projectile projectile);
}