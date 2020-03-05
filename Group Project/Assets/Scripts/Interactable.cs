using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Inventory inventory;
    public NavMeshAgent playerAgent;
    public string itemName; //Each item must have an unique name
    public Texture itemPreview;
    public GameObject slot;
    public GameObject image;
    Clues clues;
    RawImage m_RawImage;
    Text text;

    private void Start()
    {
        clues = GameObject.FindGameObjectWithTag("Clues").GetComponent<Clues>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Press 'f' to interact with object");

            if (Input.GetKeyDown(KeyCode.F))
            {
           
                Debug.Log("woot wooot");
                if(gameObject.CompareTag("Inventory Item"))
                {
                    for (int i = 0; i < inventory.items.Length; i++)
                    {
                        if (inventory.items[i] == -1)
                        { // check whether the slot is EMPTY
                            clues.logItem(itemName);
                            inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                            slot = inventory.slots[i];
                            m_RawImage = slot.transform.GetChild(1).GetComponent<RawImage>();
                            //text = slot.transform.GetChild(1).GetComponent<Text>();
                            image = slot.transform.GetChild(1).gameObject;
                            image.SetActive(true);
                            m_RawImage.texture = itemPreview;
                            //Instantiate(itemButton, inventory.slots[i].transform, false);
                            Destroy(gameObject);
                            break;
                        }
                    }
                    //Destroy(gameObject);
                }
                else if(gameObject.CompareTag("Dialogue Item"))
                {
                    Debug.Log("HERE IS SOME DIALOGUE");
                }
            }
        }
    }

}
