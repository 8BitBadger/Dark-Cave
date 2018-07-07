using System.Collections.Generic;
using UnityEngine;

namespace AiLogic
{
    public class StateController : MonoBehaviour
    {
        public State currentState;
        public State remainState;

        //Stats for the enemies, its a scriptable object helping us to create different stats for different enmies,
        //we can only use the scriptable objecgt here to share health becuase we are not haring of the same enemy types
        //so we wont have for example two barberians at the same time.

        public ActorStats statsToAdd;
        [HideInInspector] public ActorStats stats;

        //The target to chase
        [HideInInspector] public Transform chaseTarget;
        //Built in timer for the ai states to run a certain time
        [HideInInspector] public float stateTimeElapsed;
        //The rigidbody for the enemy AI
        [HideInInspector] public Rigidbody2D rb2d;
        [HideInInspector] public Vector2 randomWanderPoint = Vector2.zero;
        [HideInInspector] public Vector2 lastSeenPoint = Vector2.zero;
        [HideInInspector] public Vector2 lastPosition = Vector2.zero;
        [HideInInspector] public float lastTimeMoved;

        [HideInInspector] public float speed;

        private bool aiActive;

        //Stores the time of hte last attack. Used for 
        [HideInInspector] public float timeSinceLastAttack;

        void Awake()
        {
            timeSinceLastAttack = Time.time;
            stats = Instantiate(statsToAdd);
            //tankShooting = GetComponent<Complete.TankShooting>();
            //navMeshAgent = GetComponent<NavMeshAgent>();
            rb2d = GetComponent<Rigidbody2D>();
            //Calculate agility for charecter
            stats.agility = stats.agility + stats.agilityModifier;
            stats.strengthModifier = 3;


        }

        //TODO: Probable going to use this DO NOT delete
        public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
        {
            //wayPointList = wayPointsFromTankManager;
            aiActive = aiActivationFromTankManager;
            if (aiActive)
            {
                //navMeshAgent.enabled = true;
            }
            else
            {
                //navMeshAgent.enabled = false;
            }
        }

        void Update()
        {
            currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
            {
                currentState = nextState;
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }

        public void Speed(float _speed)
        {
            stats.speed = _speed;
            speed = (float)(stats.speed + (3 + (stats.agility / 5)) * Time.deltaTime);
        }

        public void TakeDamage(int damage)
        {
            //Do take damage animation
            stats.health -= damage;

            if (stats.health <= 0)
            {
                Die();
            }
        }

        public int CalculateDamage()
        {
            return (((stats.strength + stats.strengthModifier) / 5));
        }

        void Die()
        {
            //Play death animation
            //Drop crystal
            Destroy(gameObject);
        }

        void DropCrystal()
        {
            //TODO: detirmine the crystel worth according to the monster stats
        }
    }
}