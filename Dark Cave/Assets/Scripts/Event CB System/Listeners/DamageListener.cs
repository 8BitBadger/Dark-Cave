using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class DamageListener : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            ActorDamageEvent.RegisterListener(OnActorDamaged);
        }

        void OnDestroy()
        {
            ActorDamageEvent.UnregisterListener(OnActorDamaged);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnActorDamaged(ActorDamageEvent actorDamage)
        {
            Debug.Log("I hear " + actorDamage.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }
    }
}