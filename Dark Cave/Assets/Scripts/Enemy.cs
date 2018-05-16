using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ActorStats stats;

    //The Rigidbody2D for the Actor
    private Rigidbody2D rb2d;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        stats.speedModifier = 1f;

        if (gameObject.GetComponent<Rigidbody2D>())
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            //Set up the rigibody2d component for the actor
            //SetUpRigidBody();
        }

        //animator = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        //Do take damage animation
        stats.health -= damage;

        if(stats.health <= 0)
        {

        }
    }

    void Die()
    {
        //Play death animation
        //Drop crystal
        Destroy(gameObject);
    }

    void DropCrystal()
    {
        //TODO: detirmine the crystel worth according to the monster stats
    }

}
