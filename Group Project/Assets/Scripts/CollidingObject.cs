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

    private float savespeed;
    private Quaternion saverot;

    private void Start()
    {
        navMesh = parent.GetComponent<NavMeshAgent>();
        savespeed = navMesh.speed;
        saverot = parent.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            gameEnding.CaughtPlayer();
        }
        if (other.transform == flashlight)
        {
            navMesh.speed = 0;
            saverot = parent.transform.rotation;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform == flashlight)
        {
            /* Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                { */
                    Debug.Log("Hitting ghost.");
                    parent.transform.Rotate(Vector3.up, 20);

                    health -= 1;
                    if (health == 0)
                    {
                        Destroy(parent);
                        Debug.Log("Ghost killed.");
                    }
                /* }
                else
                {
                    Debug.Log("Not hitting ghost.");
                }
            } */
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == flashlight)
        {
            navMesh.speed = savespeed;
            parent.transform.rotation = saverot;
        }
    }

    void Update()
    {

    }
}