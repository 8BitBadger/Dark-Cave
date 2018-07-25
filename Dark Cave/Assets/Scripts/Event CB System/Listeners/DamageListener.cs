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
            PlayerDamageEvent.RegisterListener(OnPlayerDamaged);
            EnemyDamageEvent.RegisterListener(OnEnemyDamaged);
            TileDamageEvent.RegisterListener(OnTileDamaged);
        }

        void OnDestroy()
        {
            PlayerDamageEvent.UnregisterListener(OnPlayerDamaged);
            EnemyDamageEvent.UnregisterListener(OnEnemyDamaged);
            TileDamageEvent.UnregisterListener(OnTileDamaged);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnPlayerDamaged(PlayerDamageEvent playerDamage)
        {
            Debug.Log("I hear " + playerDamage.player_go.name + " has taken damage - Report from the DamageListener");
        }

        void OnEnemyDamaged(EnemyDamageEvent enemyDamage)
        {
            Debug.Log("I hear " + enemyDamage.enemy_go.name + " has taken damage - Report from the DamageListener");
        }

        void OnTileDamaged(TileDamageEvent tileDamage)
        {
            Debug.Log("I hear " + tileDamage.tile_go.name + " has taken damage - Report from the DamageListener");
        }
    }
}