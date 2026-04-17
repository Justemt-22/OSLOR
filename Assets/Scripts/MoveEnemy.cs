using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }


    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
            {
                Destroy(gameObject);

            }
        }
            
    }

}
