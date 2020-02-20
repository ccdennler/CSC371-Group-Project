using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollidingObject : MonoBehaviour
{
    public Transform player;
    public GameObject parent;
    public Transform flashlight;
    public GameEnding gameEnding;
    public NavMeshAgent navMesh;

    public float health = 100.0f;

    private void Start()
    {
        navMesh = parent.GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            gameEnding.CaughtPlayer();
        }
        if (other.transform == flashlight)
        {
            navMesh.speed = 0.5f * navMesh.speed;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform == flashlight)
        {
            Debug.Log("Hitting ghost.");
            
            health -= 1;
            if (health == 0)
            {
                Destroy(parent);
                Debug.Log("Ghost killed.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == flashlight)
        {
            navMesh.speed = 2f * navMesh.speed;
        }
    }

    void Update()
    {

    }
}