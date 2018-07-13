using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class EnemyLogic : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
          
        }
        
        void HealEnemy()
        {
            
        }

        void DamageEnemy()
        {
            ActorDamageEvent actorDamageEventInfo = new ActorDamageEvent();
            actorDamageEventInfo.Description = "Actorr] " + gameObject.name + " has taken damage.";
            actorDamageEventInfo.ActorGO = gameObject;
            actorDamageEventInfo.FireEvent();
        }

        void EnemyDie()
        {
            ActorDeathEvent actorDeathEventInfo = new ActorDeathEvent();
            actorDeathEventInfo.Description = "Actor "+ gameObject.name +" has died.";
            actorDeathEventInfo.ActorGO = gameObject;
            actorDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void EnemyAttack()
        {
            ActorAttackEvent actorAttackEventiInfo = new ActorAttackEvent();
            actorAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            actorAttackEventiInfo.ActorGO = gameObject;
            actorAttackEventiInfo.FireEvent();
        }

        void EnemyHit()
        {
            ActorHitEvent actorHitEventInfo = new ActorHitEvent();
            actorHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            actorHitEventInfo.ActorGO = gameObject;
            actorHitEventInfo.FireEvent();
        }
    }
}