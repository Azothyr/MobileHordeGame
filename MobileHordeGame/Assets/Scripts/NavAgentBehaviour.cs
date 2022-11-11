using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3Data playerLoc;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    public void SetV3ToPlayer()
    {
        agent.destination = playerLoc.value;
    }

    public void SetToCurrentLocation()
    {
        agent.destination = transform.position;
    }

    public void SetMovementVariables(float num)
    {
        agent.speed = num;
    }
}
