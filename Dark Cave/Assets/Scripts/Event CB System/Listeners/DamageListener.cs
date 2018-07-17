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
            Debug.Log("I hear " + playerDamage.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }

        void OnEnemyDamaged(EnemyDamageEvent enemyDamage)
        {
            Debug.Log("I hear " + enemyDamage.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }

        void OnTileDamaged(TileDamageEvent tileDamage)
        {
            Debug.Log("I hear " + tileDamage.ActorGO.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }
    }
}