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

        void Heal(MapSystem.Tile _tile)
        {
            
        }

        void TakeDamage(MapSystem.Tile _tile)
        {
            TileDamageEvent tileDamageEventInfo = new TileDamageEvent();


            tileDamageEventInfo.Description = "Actorr] " + gameObject.name + " has taken damage.";
            tileDamageEventInfo.tile_go = gameObject;
            tileDamageEventInfo.FireEvent();
        }

        void TileDie(MapSystem.Tile _tile)
        {
            TileDeathEvent tileDeathEventInfo = new TileDeathEvent();
            tileDeathEventInfo.Description = "Actor "+ gameObject.name +" has died.";
            tileDeathEventInfo.tile_go = gameObject;
            tileDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void TileAttack(MapSystem.Tile _tile)
        {
            TileAttackEvent tileAttackEventiInfo = new TileAttackEvent();
            tileAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            tileAttackEventiInfo.tile_go = gameObject;
            tileAttackEventiInfo.FireEvent();
        }

        void TileHit(MapSystem.Tile _tile)
        {
            TileHitEvent tileHitEventInfo = new TileHitEvent();
            tileHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            tileHitEventInfo.tile_go = gameObject;
            tileHitEventInfo.FireEvent();
        }
    }
}