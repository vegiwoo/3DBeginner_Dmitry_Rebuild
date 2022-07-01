using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    [SerializeField, Range(0.5f,3.0f)] private float speed;
    public Transform[] waypoints;

    private int m_CurrentWaypointIndex;

    private void Start ()
    {
        navMeshAgent.SetDestination (waypoints[0].position);
        navMeshAgent.speed = speed;
    }

    private void Update ()
    {
        if (!(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)) return;
        
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
    }
}
