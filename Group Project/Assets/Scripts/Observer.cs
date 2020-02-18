using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public GameObject parent;
    private HomingPatrol patrol;

    bool playerInSight;

    private void Start()
    {
        patrol = parent.GetComponent<HomingPatrol>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerInSight = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerInSight = false;
            patrol.StopFollowing();
        }
    }

    void Update()
    {
        if (playerInSight)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    patrol.FollowPlayer();
                }
            }
        }
    }
}
