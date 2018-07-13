using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class TileLogic : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
          
        }
        
        void HealTile()
        {
            
        }

        void DamageTile()
        {
            ActorDamageEvent actorDamageEventInfo = new ActorDamageEvent();
            actorDamageEventInfo.Description = "Actorr] " + gameObject.name + " has taken damage.";
            actorDamageEventInfo.ActorGO = gameObject;
            actorDamageEventInfo.FireEvent();
        }

        void TileDie()
        {
            ActorDeathEvent actorDeathEventInfo = new ActorDeathEvent();
            actorDeathEventInfo.Description = "Actor "+ gameObject.name +" has died.";
            actorDeathEventInfo.ActorGO = gameObject;
            actorDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void TileAttack()
        {
            ActorAttackEvent actorAttackEventiInfo = new ActorAttackEvent();
            actorAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            actorAttackEventiInfo.ActorGO = gameObject;
            actorAttackEventiInfo.FireEvent();
        }

        void TileHit()
        {
            ActorHitEvent actorHitEventInfo = new ActorHitEvent();
            actorHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            actorHitEventInfo.ActorGO = gameObject;
            actorHitEventInfo.FireEvent();
        }
    }
}