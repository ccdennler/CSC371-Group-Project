using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static int[] items = new int[8];
    public static GameObject[] slots = new GameObject[8];
    public GameObject[] slot;
    public static GameObject[] availableItems = new GameObject[4];
    public GameObject[] available;
    public static string[] names = new string[8];
    private static int location;
    static RawImage m_RawImage;
    static RawImage m_RawImage1;
    static RawImage m_RawImage2;



    void Start()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            slots[i] = slot[i];
        }
        //Initialize Item Slots
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = -1;
        }
        for (int i = 0; i < available.Length; i++)
        {
            availableItems[i] = available[i];
        }
    }

    public static void removeItem(string name)
    {
       for (int i = 0; i < items.Length; i++)
        {
            if (names[i] == name)
            {
                GameObject tmpSlot = slots[i];
                m_RawImage = tmpSlot.transform.GetChild(1).GetComponent<RawImage>();
                GameObject image = tmpSlot.transform.GetChild(1).gameObject;
                image.SetActive(false);
                m_RawImage.texture = null;
                items[i] = -1;
                location = i + 1;
            }
        }

       for (int i = location; i < items.Length; i++)
        {
            Debug.Log(i);
            if (items[i] != -1)
            {
                
                string tmpName = names[i];
                int tmpItem = items[i];
                GameObject tmpSlot = slots[i];
                m_RawImage1 = tmpSlot.transform.GetChild(1).GetComponent<RawImage>();
                GameObject image1 = tmpSlot.transform.GetChild(1).gameObject;
                GameObject tmpSlot2 = slots[i - 1];
                m_RawImage2 = tmpSlot2.transform.GetChild(1).GetComponent<RawImage>();
                GameObject image2 = tmpSlot2.transform.GetChild(1).gameObject;
                image1.SetActive(false);
                m_RawImage2.texture = m_RawImage1.texture;
                m_RawImage1.texture = null;
                image2.SetActive(true);
                names[i - 1] = tmpName;
                items[i - 1] = tmpItem;
                names[i] = "";
                items[i] = -1;
            }
        }
    }

    public static void addItem(string name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == -1)
            {
                for (int y = 0; y < availableItems.Length; y++)
                {
                    if (availableItems[y].name == name)
                    {
                        items[i] = 1; // makes sure that the slot is now considered FULL
                        GameObject slot1 = slots[i];
                        names[i] = name;
                        m_RawImage = slot1.transform.GetChild(1).GetComponent<RawImage>();
                        GameObject image = slot1.transform.GetChild(1).gameObject;
                        m_RawImage.texture = availableItems[y].GetComponent<Interactable>().itemPreview;
                        image.SetActive(true);
                    }
                }
                break;
            }
        }
    }
}