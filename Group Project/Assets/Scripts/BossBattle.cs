using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for player behavior in only the boss battle
public class BossBattle : MonoBehaviour
{
    public static int piecesLeft;
    // Start is called before the first frame update
    void Start()
    {
        piecesLeft = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Inventory Item")
        {
            Destroy(other.gameObject);
            piecesLeft--; 
        }
    }
}
