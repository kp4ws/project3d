using UnityEngine;
using UnityEngine.AI;

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

        private float distanceToTarget = Mathf.Infinity;


        private void Update()
        {
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
            agent.SetDestination(target.position);
        }

        private void AttackTarget()
        {
            Debug.Log(name + " has seeked and is destroying " + target.name);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
        }
    }
}