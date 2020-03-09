using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Clues : MonoBehaviour
{
    public static bool hasEgg = false;
    public static bool hasCakeMix = false;
    public static bool hasButter = false;
    public static bool hasCake = false;
    public static bool hasKey1 = false;
    public static bool hasFur = false;

    public static void logItem(string name)
    {
        if (name == "Cake Mix")
        {
            hasCakeMix = true;
        }
        if (name == "Egg")
        {
            hasEgg = true;
        }
        if (name == "Butter")
        {
            hasButter = true;
        }
    }
}
