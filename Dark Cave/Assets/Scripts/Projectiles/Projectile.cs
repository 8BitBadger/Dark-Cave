using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileStats tempStats;
    private ProjectileStats projectileStats;
    
    public List<ProjectileAction> tempAction;
    private List<ProjectileAction> action;

    private Transform target;

    //private Vector2 staticDir;

    public Transform Target
    {
        set { target = value; }
    }

    void Start()
    {
        projectileStats = Instantiate(tempStats);

        projectileStats.Target = target;
        projectileStats.Rb2d = GetComponent<Rigidbody2D>();
        projectileStats.SpawnTime = Time.time;

        foreach (ProjectileAction act in tempAction)
        {
            action.Add(Instantiate(act));
        } 
    }

    private void Update()
    {
        foreach (ProjectileAction action in action)
        {
            if ((Time.time - projectileStats.SpawnTime) >= action.delayedEffectTimerTrigger)
            {
               action.DoAction(projectileStats); 
            }
        }

        if ((Time.time - projectileStats.SpawnTime) >= projectileStats.projectileLife)
        {
            Destroy(gameObject);
        }
    }
}