using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCbSystem
{
    public class EnemyEvents : MonoBehaviour
    {
        //This is just to split the events this class serves no purpose yet!!
    }

    public class EnemyDeathEvent : Event<EnemyDeathEvent>
    {
        public GameObject ActorGO;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class EnemyDamageEvent : Event<EnemyDamageEvent>
    {
        public GameObject ActorGO;

        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class EnemyAttackEvent : Event<EnemyAttackEvent>
    {
        public GameObject ActorGO;

        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class EnemyHitEvent : Event<EnemyHitEvent>
    {
        public GameObject ActorGO;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }
}