using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectileStats")]
public class ProjectileStats : ScriptableObject
{

    //TODO: Later animation needs to be added and a few more things
    //public Animation projectileAnimation;
    //public GameObject hitAnimation;
    

    public float speed;
    public float rotateSpeed;
    public float projectileLife; //How long the projectile will persist in the world
    private float spawnTime; //The time the projectile was spawned.
    public float delayedEffectTimerTrigger; //The follow target bool will become active after this amount of seconds

    public float SpawnTime
    {
        set { spawnTime = value; }
        get { return spawnTime; }
    }

    private Rigidbody2D rb2d;
    public Rigidbody2D Rb2d
    {
        set { rb2d = value; }
        get {return rb2d;}
    }
    
    private Transform target;
    public Transform Target
    {
        set { target = value; }
        get { return target;}
    }
}