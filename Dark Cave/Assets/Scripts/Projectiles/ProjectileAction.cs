using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileAction : ScriptableObject
{
    public abstract DoAction(ProjectileStats stats);
}