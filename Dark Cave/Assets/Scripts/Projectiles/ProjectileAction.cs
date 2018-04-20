using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileAction : ScriptableObject
{
    public abstract void DoAction(ProjectileStats stats);
}