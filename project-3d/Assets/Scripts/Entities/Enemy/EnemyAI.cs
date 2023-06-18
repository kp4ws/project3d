using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRadius = 5f;
    [SerializeField] private NavMeshAgent agent;

    private bool isProvoked = false;

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
            isProvoked = true;
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