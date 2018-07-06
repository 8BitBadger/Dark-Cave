using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class ActorLogic : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                DamageActor();
            }
        }
        
        void HealActor()
        {
            
        }

        void DamageActor()
        {
            ActorDamageEvent actorDamageEventInfo = new ActorDamageEvent();
            actorDamageEventInfo.Description = "Unit " + gameObject.name + " has taken damage.";
            actorDamageEventInfo.ActorGO = gameObject;
            actorDamageEventInfo.FireEvent();
        }

        void ActorDie()
        {
            // I am dying for some reason.

            ActorDeathEvent actorDeathEventInfo = new ActorDeathEvent();
            actorDeathEventInfo.Description = "Unit "+ gameObject.name +" has died.";
            actorDeathEventInfo.ActorGO = gameObject;
            actorDeathEventInfo.FireEvent();

            Destroy(gameObject);
        }
    }
}