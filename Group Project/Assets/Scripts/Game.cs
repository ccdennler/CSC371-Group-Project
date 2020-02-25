using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public int stage = 1;
    public GameObject player;
    public GameObject dialogueSystem;
    public Movement playerMovement;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<Movement>();
        dialogue = dialogueSystem.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isTalking)
        {
            dialogue.setDialogue(playerMovement.talkingTo, stage);
        }
    }
}
