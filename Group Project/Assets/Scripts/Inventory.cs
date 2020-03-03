using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int[] items = new int[8];
    public GameObject[] slots;
    public Interactable[] availableItems;


    void Start()
    {
        //Initialize Item Slots
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = -1;
        }
    }


}