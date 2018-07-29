using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCbSystem
{
    public class PlayerLogic : MonoBehaviour
    {

        public UnitStats stats;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
          
        }

        public void TakeDamage(int damage)
        {
            stats.health -= damage;
            Debug.Log("Health = " + stats.health);
        }

        public int CalculateDamage()
        {
            return (((stats.strength + stats.strengthModifier) / 5));
        }

        void HealPlayer()
        {
            
        }

        void DamagePlayer()
        {
            PlayerDamageEvent playerDamageEventInfo = new PlayerDamageEvent();
            playerDamageEventInfo.Description = "Actorr] " + gameObject.name + " has taken damage.";
            playerDamageEventInfo.player_go = gameObject;
            playerDamageEventInfo.FireEvent();
        }

        void PlayerDie()
        {
            PlayerDeathEvent playerDeathEventInfo = new PlayerDeathEvent();
            playerDeathEventInfo.Description = "Actor "+ gameObject.name +" has died.";
            playerDeathEventInfo.player_go = gameObject;
            playerDeathEventInfo.FireEvent();

            Destroy(gameObject);
        } 
        void PlayerAttack()
        {
            PlayerAttackEvent playerAttackEventiInfo = new PlayerAttackEvent();
            playerAttackEventiInfo.Description = "Unit " + gameObject.name + " has just attacked";
            playerAttackEventiInfo.player_go = gameObject;
            playerAttackEventiInfo.FireEvent();
        }

        void PlayerHit()
        {
            PlayerHitEvent playerHitEventInfo = new PlayerHitEvent();
            playerHitEventInfo.Description = "Actor " + gameObject.name + " has hit something";
            playerHitEventInfo.player_go = gameObject;
            playerHitEventInfo.FireEvent();
        }
    }
}