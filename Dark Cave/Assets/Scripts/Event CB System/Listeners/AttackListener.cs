using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
public class AttackListener : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            PlayerAttackEvent.RegisterListener(OnPlayerAttack);
            EnemyAttackEvent.RegisterListener(OnEnemyAttack);
            TileAttackEvent.RegisterListener(OnTileAttack);
        }

        void OnDestroy()
        {
            PlayerAttackEvent.UnregisterListener(OnPlayerAttack);
            EnemyAttackEvent.UnregisterListener(OnEnemyAttack);
            TileAttackEvent.UnregisterListener(OnTileAttack);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnPlayerAttack(PlayerAttackEvent playerAttack)
        {
            Debug.Log("I hear " + playerAttack.player_go.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }

        void OnEnemyAttack(EnemyAttackEvent enemyAttack)
        {
            Debug.Log("I hear " + enemyAttack.enemy_go.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }

        void OnTileAttack(TileAttackEvent tileAttack)
        {
            Debug.Log("I hear " + tileAttack.tile_go.name + " has taken damage, that is to bad, but at least we know the Event cb system is working fine now - Report from the DamageListener");
        }
    }
}
