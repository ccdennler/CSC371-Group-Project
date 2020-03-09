using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Clues : MonoBehaviour
{
    public bool hasEgg;
    public bool hasCakeMix;
    public bool hasButter;
    public bool hasCake;
    public bool hasKey1;
    public bool hasFur;

    // Start is called before the first frame update
    void Start()
    {
        hasEgg = false;
        hasCakeMix = false;
        hasButter = false;
        hasCake = false;
        hasKey1 = false;
        hasFur = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
