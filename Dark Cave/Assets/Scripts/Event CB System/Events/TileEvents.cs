using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCbSystem
{
    public class TileEvents : MonoBehaviour
    {
        //This is just to split the events this class serves no purpose yet!!
    }

    public class TileDeathEvent : Event<TileDeathEvent>
    {
        public GameObject tile_go;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class TileDamageEvent : Event<TileDamageEvent>
    {
        public GameObject tile_go;

        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class TileAttackEvent : Event<TileAttackEvent>
    {
        public GameObject tile_go;

        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }

    public class TileHitEvent : Event<TileHitEvent>
    {
        public GameObject tile_go;
        /*

        Info about cause of death, our killer, etc...

        Could be a struct, readonly, etc...

        */
    }
}