using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
public class AttackListener : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            ActorAttackEvent.RegisterListener(OnActorAttack);
        }

        void OnDestroy()
        {
            ActorAttackEvent.UnregisterListener(OnActorAttack);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnActorAttack(ActorAttackEvent actorAttack)
        {
            Debug.Log("I hear " + actorAttack.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }
    }
}
