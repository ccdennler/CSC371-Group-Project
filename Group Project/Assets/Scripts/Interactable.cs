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
                    if (Inventory.addItem(itemName))
                    {
                        gameObject.SetActive(false);
                    }
                }

            }
            if (Input.GetMouseButtonDown(0))
            {
                if (itemName == "SecretBookcase" && Clues.hasBook)
                {
                    gameObject.SetActive(false);
                }
                if (itemName == "LibDoor" && Clues.hasKey1)
                {
                    gameObject.SetActive(false);
                }
                if (itemName == "ColDoor" && Clues.hasKey2)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
