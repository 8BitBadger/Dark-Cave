using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class DeathListener : MonoBehaviour
    {
        public GameObject CrystalToSpawn;

        // Use this for initialization
        void Start()
        {
            ActorDeathEvent.RegisterListener(OnActorDeath);
        }

        void OnDestroy()
        {
            ActorDeathEvent.UnregisterListener(OnActorDeath);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnActorDeath(ActorDeathEvent actorDeath)
        {
            if (actorDeath.ActorGO.tag == "Enemy")
            {
                Instantiate(CrystalToSpawn, actorDeath.ActorGO.transform);
            }
            Debug.Log("I hear " + actorDeath.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }
    }
}