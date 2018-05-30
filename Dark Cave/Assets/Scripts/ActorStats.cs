using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType
{
    Player,
    Slime,
    Spider,
    Skeleton,
    Beholder,
    VoidWanderer
};

[CreateAssetMenu(menuName = "Actor Stats")]

public class ActorStats : ScriptableObject
{
    //Identifies if the player is human or non human
    public bool AI;

    public ActorType type;

    public int strength;
    public int agility;
    public int stamina;
    public int intelligence;

    //he health of the actor
    public int health;
    //The endurance of the Actor used for attacking, blocking and mining
    public int endurance;
    //The walk speed of the actor
    public float speed;

    //The maximum speed moddifier for the actor 
    [HideInInspector] public float speedModifier;

    //The wander distance of the AI
    public float wanderDistance;

    //Attack range used for the player as well as the ai
    public float attackRange;
    //The times the player or AI can attack in a certain time
    public float attackInterval;
    //The base damage the actor can do
    public int baseDamage;

    //Used for the fow script
    public float viewRadius;
    public float viewAngle;
    public float viewDistance; //Used for the players field of view
    public LayerMask obstacleMask;
    public LayerMask targetLayer;

    //The abilities of the actor
    public List<Ability> abilities;

    private void OnEnable()
    {

    }
}
