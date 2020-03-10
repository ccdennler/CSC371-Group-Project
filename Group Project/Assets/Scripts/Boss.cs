using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform flashlight;
    public Transform target;
    public int damageTaken;
    public int spinTime;
    public bool spin;
    // Start is called before the first frame update
    void Start()
    {
        damageTaken = 0;
        spin = false;
        spinTime = 200;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(target.position);
        if (spin)
        {
            spinTime--;
            this.transform.Rotate(Vector3.up, 20);
            agent.isStopped = true;
        }
        if(spinTime <= 0)
        {
            agent.isStopped = false;
            spin = false;
            spinTime = 200;
            damageTaken = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform == target.transform)
        {
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform == flashlight.transform)
        {
            if (damageTaken < 100)
            {
                damageTaken++;
            }
            if(damageTaken >= 100)
            {
                spin = true;              
            }           
        }
        
    }
}
