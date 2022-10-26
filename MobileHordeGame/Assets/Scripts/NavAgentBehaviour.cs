using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    //change this later to private v
    public Vector3Data playerLoc;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void SetV3Value()
    {
        agent.destination = playerLoc.value;
    }


}
