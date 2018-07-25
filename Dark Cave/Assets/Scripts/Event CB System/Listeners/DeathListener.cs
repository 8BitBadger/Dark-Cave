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
            PlayerDeathEvent.RegisterListener(OnPlayerDeath);
            EnemyDeathEvent.RegisterListener(OnEnemyDeath);
            TileDeathEvent.RegisterListener(OnTileDeath);
        }

        void OnDestroy()
        {
            PlayerDeathEvent.UnregisterListener(OnPlayerDeath);
            EnemyDeathEvent.UnregisterListener(OnEnemyDeath);
            TileDeathEvent.UnregisterListener(OnTileDeath);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnPlayerDeath(PlayerDeathEvent playerDeath)
        {
            //Debug.Log("I hear " + playerDeath.player_go.name + " has died - Report from the DeathListener");
        }

        void OnEnemyDeath(EnemyDeathEvent enemyDeath)
        {
            Instantiate(CrystalToSpawn, enemyDeath.enemy_go.transform);
            Debug.Log("enemyDeath.enemy_go.transform -> " + enemyDeath.enemy_go.transform.position);
            //Debug.Log("I hear " + enemyDeath.enemy_go.name + " has died - Report from the DeathListener");
        }

        void OnTileDeath(TileDeathEvent tileDeath)
        {
            //Debug.Log("I hear " + tileDeath.tile_go.name + " has died - Report from the DeathListener");
        }
    }
}