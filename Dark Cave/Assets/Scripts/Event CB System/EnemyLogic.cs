using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class EnemyLogic : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
          
        }
        
        void HealEnemy()
        {
            
        }

        void DamageEnemy()
        {
            EnemyDamageEvent enemyDamageEventInfo = new EnemyDamageEvent();
            enemyDamageEventInfo.Description = "Actorr] " + gameObject.name + " has taken damage.";
            enemyDamageEventInfo.ActorGO = gameObject;
            enemyDamageEventInfo.FireEvent();
        }

        void EnemyDie()
        {
            EnemyDeathEvent enemyDeathEventInfo = new EnemyDeathEvent();
            enemyDeathEventInfo.Description = "Actor "+ gameObject.name +" has died.";
            enemyDeathEventInfo.ActorGO = gameObject;
            enemyDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void EnemyAttack()
        {
            EnemyAttackEvent enemyAttackEventiInfo = new EnemyAttackEvent();
            enemyAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            enemyAttackEventiInfo.ActorGO = gameObject;
            enemyAttackEventiInfo.FireEvent();
        }

        void EnemyHit()
        {
            EnemyHitEvent enemyHitEventInfo = new EnemyHitEvent();
            enemyHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            enemyHitEventInfo.ActorGO = gameObject;
            enemyHitEventInfo.FireEvent();
        }
    }
}