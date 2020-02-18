using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HomingPatrol : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    private bool followPlayer;


    int m_CurrentWaypointIndex;

    // Start is called before the first frame update
    public void Start()
    {
        transform.position = waypoints[0].position;
        navMeshAgent.SetDestination(waypoints[1].position);
        followPlayer = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (followPlayer)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
        else if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }

    public void FollowPlayer()
    {
        followPlayer = true;
    }

    public void StopFollowing()
    {
        followPlayer = false;
    }
}
