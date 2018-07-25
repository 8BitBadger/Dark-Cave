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
            PlayerHitEvent.RegisterListener(OnPlayerHit);
            EnemyHitEvent.RegisterListener(OnEnemyHit);
            TileHitEvent.RegisterListener(OnTileHit);
        }

        void OnDestroy()
        {
            PlayerHitEvent.UnregisterListener(OnPlayerHit);
            EnemyHitEvent.UnregisterListener(OnEnemyHit);
            TileHitEvent.UnregisterListener(OnTileHit);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnPlayerHit(PlayerHitEvent playerHit)
        {
            Debug.Log("I hear " + playerHit.player_go.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the HitListener");
        }

        void OnEnemyHit(EnemyHitEvent enemyHit)
        {
            Debug.Log("I hear " + enemyHit.enemy_go.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the HitListener");
        }

        void OnTileHit(TileHitEvent tileHit)
        {
            Debug.Log("I hear " + tileHit.tile_go.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the HitListener");
        }
    }
}
