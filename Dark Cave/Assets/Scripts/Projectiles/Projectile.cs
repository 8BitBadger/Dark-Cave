using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public List<ProjectileAction> action;

    private Rigidbody2D rb2d;
    public Rigidbody2D Rb2d
    {
        get { return rb2d;}
        set { rb2d = value; }
    }

    private Transform target;

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }


    private float spawnTime; //The time the projectile was spawned.
    public int projectileLife;

    //TODO: Later animation needs to be added and a few more things
    //public Animation projectileAnimation;
    //public GameObject hitAnimation;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        spawnTime = Time.time;
    }

    private void Update()
    {
        foreach (ProjectileAction tmpAction in action)
        {
            if ((Time.time - spawnTime) >= tmpAction.delayedEffectTimerTrigger)
            {
                tmpAction.DoAction(this); 
            }
        }

        if ((Time.time - spawnTime) >= projectileLife)
        {
            Destroy(gameObject);
        }
    }
}