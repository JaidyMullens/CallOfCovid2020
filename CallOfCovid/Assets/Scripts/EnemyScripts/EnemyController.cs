using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
       
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);


            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                // Face the target
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        // Get direction to the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Get rotation where we point to the target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Update own direction to point to this direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
