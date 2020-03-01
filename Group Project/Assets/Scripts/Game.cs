using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public int stage = -1;
    public GameObject player;
    public GameObject dialogueSystem;
    public GameObject intro;
    GameObject dialogue;
    Text characterName;
    TypewriterText typewriter;
    Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == -1)
        {
            StartIntroduction();
        }
        else
        {
            CheckDialogue();
            ChangeStage();
        }
    }



    private void StartIntroduction()
    {
        intro.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            stage = 0;
            intro.SetActive(false);
        }
    }

    private void CheckDialogue()
    {
        if (playerMovement.isTalking)
        {
            if (dialogue == null)
            {
                dialogue = Instantiate(dialogueSystem, new Vector3(0, 0, 0), Quaternion.identity);
                dialogue.SetActive(true);
                SetDialogue(playerMovement.talkingTo, stage);
            }


        }
        else
        {
            Destroy(dialogue);
        }
    }

    private void SetDialogue(string name, int stage)
    {
        characterName = dialogue.transform.GetChild(0).transform.GetComponent<Text>();
        characterName.text = name;
        typewriter = dialogue.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TypewriterText>();
        typewriter.fullText = DialogueSystem.GetText(name, stage);
    }

    private void ChangeStage()
    {
        if (Input.GetKeyDown("x"))
        {
            if (stage == 4) {
                stage = 0;
            }
            else
            {
                stage = stage + 1;
            }
        }
    }
}
