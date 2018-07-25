using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCbSystem
{
    public class PlayerEvents : MonoBehaviour
    {
        //This is just to split the events this class serves no purpose yet!!
    }

    public class PlayerDeathEvent : Event<PlayerDeathEvent>
    {
        public GameObject player_go;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class PlayerDamageEvent : Event<PlayerDamageEvent>
    {
        public GameObject player_go;

        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class PlayerAttackEvent : Event<PlayerAttackEvent>
    {
        public GameObject player_go;

        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class PlayerHitEvent : Event<PlayerHitEvent>
    {
        public GameObject player_go;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }
}