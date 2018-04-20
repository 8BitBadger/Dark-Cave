using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileStats tempStats;
    private ProjectileStats projectileStats;
    
    public List<ProjectileAction> tempImmediateAction;
    private List<ProjectileAction> immediateAction;

    public List<ProjectileAction> tempdelayedAction;
    private List<ProjectileAction> delayedAction;

    private Transform target;

    private Vector2 staticDir;
    float spawnTime = 0;

    public Transform Target
    {
        set { target = value; }
    }

    void Start()
    {

        //TODO: Sort this shit and move what needs to moved to the ProjectileFollowAction script
        projectileStats = Instantiate(tempStats);

        projectileStats.Target = target;
        projectileStats.Rb2d = GetComponent<Rigidbody2D>();

        foreach (projectileAction action in tempImmediateAction)
        {
            immediateAction.Add(Instantiate(action));
        }

        foreach (projectileAction action in tempdelayedAction)
        {
            delayedAction.Add(Instantiate(action));
        }

        //projectileStats.spawnTime = Time.time;
        spawnTime = Time.time;
        

        staticDir = new Vector2(target.position.x, target.position.y) - rb2d.position;
        staticDir.Normalize();
    }

    void FixedUpdate()
    {
        if ((Time.time - spawnTime) >= projectileStats.projectileLife)
        //if ((Time.time - projectileStats.spawnTime) >= projectileStats.projectileLife)
        {
            Destroy(gameObject);
        }

        if(projectileStats.hasDelaydEffect && (Time.time - spawnTime) >= projectileStats.delayEffectTimerTrigger)
        //if (projectileStats.hasDelaydEffect && (Time.time - projectileStats.spawnTime) >= projectileStats.delayEffectTimerTrigger)
        {
            projectileStats.followTarget = true;
        }
        
        Vector2 dir = new Vector2(target.position.x, target.position.y) - rb2d.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, transform.up).z;

        if (projectileStats.followTarget)
        {
            rb2d.angularVelocity = -rotateAmount * projectileStats.rotateSpeed;
            rb2d.velocity = dir * projectileStats.speed;
        }
        else
        {
            rb2d.velocity = staticDir * projectileStats.speed;
        }

        
    }

    private void Update()
    {
        foreach (projectileAction action in immediateAction)
        {
            action.DoAction(stats);
        }

        foreach (projectileAction action in delayedAction)
        {
            //TODO: integrate the delayedEffectTimerTrigger from the projectile stats to check the time againts the trigger every update
            action.DoAction(stats);
        }
    }
}