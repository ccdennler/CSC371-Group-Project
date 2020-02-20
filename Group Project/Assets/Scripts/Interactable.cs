using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 public class Interactable : MonoBehaviour{

    public NavMeshAgent playerAgent;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("woot wooot");
        }
    }

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.destination = this.transform.position;
        Interact();
    }
    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
