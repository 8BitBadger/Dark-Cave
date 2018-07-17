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
            Debug.Log("I hear " + playerDeath.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }

        void OnEnemyDeath(EnemyDeathEvent enemyDeath)
        {
            if (enemyDeath.ActorGO.tag == "Enemy")
            {
                Instantiate(CrystalToSpawn, enemyDeath.ActorGO.transform);
            }
            Debug.Log("I hear " + enemyDeath.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }

        void OnTileDeath(TileDeathEvent tileDeath)
        {
            Debug.Log("I hear " + tileDeath.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }
    }
}