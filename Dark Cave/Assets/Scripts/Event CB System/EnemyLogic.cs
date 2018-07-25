using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class EnemyLogic : MonoBehaviour
    {

        ActorStats stats;

        // Use this for initialization
        void Start()
        {
            stats = GetComponent<AiLogic.StateController>().stats;
        }

        // Update is called once per frame
        void Update()
        {
          
        }

        public int CalculateDamage()
        {
            return (((stats.strength + stats.strengthModifier) / 5));
        }

        void Heal()
        {
            
        }

        public void TakeDamage(int damage)
        {
            EnemyDamageEvent enemyDamageEventInfo = new EnemyDamageEvent();
            enemyDamageEventInfo.Description = "Actor " + gameObject.name + " has taken damage.";
            enemyDamageEventInfo.enemy_go = gameObject;
            enemyDamageEventInfo.FireEvent();

            //Do take damage animation
            stats.health -= damage;

            if (stats.health <= 0)
            {
                EnemyDie();
            }
        }

        public void EnemyDie()
        {
            EnemyDeathEvent enemyDeathEventInfo = new EnemyDeathEvent();
            enemyDeathEventInfo.Description = "Actor " + gameObject.name + " has died.";
            enemyDeathEventInfo.enemy_go = gameObject;
            enemyDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void EnemyAttack()
        {
            EnemyAttackEvent enemyAttackEventiInfo = new EnemyAttackEvent();
            enemyAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            enemyAttackEventiInfo.enemy_go = gameObject;
            enemyAttackEventiInfo.FireEvent();
        }

        void EnemyHit()
        {
            EnemyHitEvent enemyHitEventInfo = new EnemyHitEvent();
            enemyHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            enemyHitEventInfo.enemy_go = gameObject;
            enemyHitEventInfo.FireEvent();
        }
    }
}