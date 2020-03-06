using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public string itemName; //Each item must have an unique name
    public Texture itemPreview;


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Press 'f' to interact with object");

            if (Input.GetKeyDown(KeyCode.F))
            {
                if(gameObject.CompareTag("Inventory Item"))
                {
                    Clues.logItem(itemName);
                    Inventory.addItem(itemName);
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
