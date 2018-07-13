using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
  public class HitListener : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            ActorHitEvent.RegisterListener(OnActorHit);
        }

        void OnDestroy()
        {
            ActorHitEvent.UnregisterListener(OnActorHit);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnActorHit(ActorHitEvent actorHit)
        {
            Debug.Log("I hear " + actorHit.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the HitListener");
        }
    }
}
