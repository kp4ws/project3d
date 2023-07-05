using UnityEngine;
using UnityEngine.AI;
using Kp4wsGames.Entities.Player;

namespace Kp4wsGames.Entities.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float chaseRadius = 5f;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;

        private bool isProvoked = false;
        private bool isAlerted = false;
        private bool isAttacking = false;
        private bool isDead = false;

        private float distanceToTarget = Mathf.Infinity;
        private float originalSpeed;

        private void Start()
        {
            //TODO - EnemyAI should work like RPG course
            if (target == null)
                target = FindObjectOfType<PlayerController>().transform;

            originalSpeed = agent.speed;
        }

        private void Update()
        {
            if (isDead) return;

            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRadius)
            {
                if (!isAlerted)
                {
                    isAlerted = true;
                    animator.SetTrigger("alert");
                }
            }
            else
            {
                isAlerted = false;
            }

            UpdateAnimator();
        }

        //Animation Event
        public void Provoke()
        {
            Debug.Log("test");
            isProvoked = true;
        }

        private void UpdateAnimator()
        {
            //Velocity has a direction which is why we use Vector3 instead of float
            Vector3 globalVelocity = agent.velocity;

            //We need this as local velocity so the animator knows the velocity relative to the player
            Vector3 localVelocity = transform.InverseTransformDirection(globalVelocity);
            float speed = localVelocity.z;

            animator.SetFloat("xVelocity", speed);
            animator.SetBool("isAttacking", isAttacking);

            if (GetComponent<Health>().GetHealth() < 0.01f)
            {
                Debug.Log("test");
                isDead = true;
                animator.SetTrigger("deathTrigger");
                agent.enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }

        private void EngageTarget()
        {
            if (distanceToTarget >= agent.stoppingDistance)
            {
                agent.SetDestination(target.position);
                ChaseTarget();
            }

            if (distanceToTarget <= agent.stoppingDistance)
            {
                AttackTarget();
            }
        }

        private void ChaseTarget()
        {
            isAttacking = false;
            agent.speed = originalSpeed;
            agent.SetDestination(target.position);
        }

        private void AttackTarget()
        {
            isAttacking = true;
            agent.speed = 0;
            Debug.Log(name + " has seeked and is destroying " + target.name);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
        }
    }
}