using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                    if (Clues.hasLetter1 && itemName == "Letter 2")  
                    {
                        Inventory.removeItem("Letter 1");
                        Inventory.addItem("Letter Dad");
                        gameObject.SetActive(false);
                    }
                    else if (Clues.hasLetter2 && itemName == "Letter 1")
                    {
                        Inventory.removeItem("Letter 2");
                        Inventory.addItem("Letter Dad");
                        gameObject.SetActive(false);
                    }
                    else if (Inventory.addItem(itemName))
                    {
                        gameObject.SetActive(false);
                    }
                }

            }
            if (Input.GetMouseButtonDown(0))
            {
                if (itemName == "SecretBookcase" && Clues.hasBook)
                {
                    Destroy(gameObject);
                }
                if (itemName == "LibDoor" && Clues.hasKey1)
                {
                    Destroy(gameObject);
                }
                if (itemName == "ColDoor" && Clues.hasKey2)
                {
                    Destroy(gameObject);
                }
                if (itemName == "Dirt" && Clues.hasShovel)
                {
                    Destroy(gameObject);
                }
                if (itemName == "Missing Crate" && Clues.hasCrowbar)
                {
                    Destroy(gameObject);
                }
                if (itemName == "Ladder" && Clues.hasKey3)
                {
                    SceneManager.LoadScene("BossScene");
                }
            }
        }
    }

}
