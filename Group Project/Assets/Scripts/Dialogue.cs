using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text characterName;
    public GameObject dialogueBackground;
    public Text dialogue;

    public void setDialogue(string name, int stage)
    {
        characterName.text = name;
        dialogue.text = "I am saying stuff.";
    }
}
