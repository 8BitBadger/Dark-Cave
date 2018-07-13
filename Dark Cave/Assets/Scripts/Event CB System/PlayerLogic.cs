using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class PlayerLogic : MonoBehaviour
    {

        public ActorStats stats;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
          
        }

        public void TakeDamage(int damage)
        {
            stats.health -= damage;
            Debug.Log("Health = " + stats.health);
        }

        public int CalculateDamage()
        {
            return (((stats.strength + stats.strengthModifier) / 5));
        }

        void HealPlayer()
        {
            
        }

        void DamagePlayer()
        {
            ActorDamageEvent actorDamageEventInfo = new ActorDamageEvent();
            actorDamageEventInfo.Description = "Actorr] " + gameObject.name + " has taken damage.";
            actorDamageEventInfo.ActorGO = gameObject;
            actorDamageEventInfo.FireEvent();
        }

        void PlayerDie()
        {
            ActorDeathEvent actorDeathEventInfo = new ActorDeathEvent();
            actorDeathEventInfo.Description = "Actor "+ gameObject.name +" has died.";
            actorDeathEventInfo.ActorGO = gameObject;
            actorDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void PlayerAttack()
        {
            ActorAttackEvent actorAttackEventiInfo = new ActorAttackEvent();
            actorAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            actorAttackEventiInfo.ActorGO = gameObject;
            actorAttackEventiInfo.FireEvent();
        }

        void PlayerHit()
        {
            ActorHitEvent actorHitEventInfo = new ActorHitEvent();
            actorHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            actorHitEventInfo.ActorGO = gameObject;
            actorHitEventInfo.FireEvent();
        }
    }
}