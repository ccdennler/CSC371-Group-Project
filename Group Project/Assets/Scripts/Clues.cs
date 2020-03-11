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
    public static bool hasKey2 = false;
    public static bool hasNecklace = false;
    public static bool hasLetter = false;
    public static bool hasBook = false;
    public static bool hasCrowbar = false;
    public static bool hasLetter1 = false;
    public static bool hasLetter2 = false;
    public static bool hasLetterDad = false;
    public static bool hasDoll = false;
    public static bool hasShovel = false;
    

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
        if (name == "Necklace")
        {
            hasNecklace = true;
        }
        if (name == "Book")
        {
            hasBook = true;
        }
        if (name == "Doll")
        {
            hasDoll = true;
        }
        if (name == "Letter Dad")
        {
            hasLetterDad = true;
        }
        if (name == "Crowbar")
        {
            hasCrowbar = true;
        }
        if (name == "Key 1")
        {
            hasKey1 = true;
        }
        if (name == "Key 2")
        {
            hasKey2 = true;
        }
        if (name == "Letter 1")
        {
            hasLetter1 = true;
        }
        if (name == "Letter 2")
        {
            hasLetter2 = true;
        }
        if (name == "Shovel")
        {
            hasShovel = true;
        }
    }
}
