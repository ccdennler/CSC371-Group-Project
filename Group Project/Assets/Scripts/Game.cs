using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public int stage = -2;
    public GameObject player;
    public GameObject dialogueSystem;
    public GameObject intro;
    public GameObject title;
    GameObject dialogue;
    Text characterName;
    TypewriterText typewriter;
    Movement playerMovement;
    TypewriterText introText;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == -2)
        {
            StartTitle();
        }
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

    private void StartTitle()
    {
        title.SetActive(true);
        if (Input.GetKeyDown("space"))
        {
            stage = -1;
            title.SetActive(false);
        }
    }


    private void StartIntroduction()
    {
        intro.SetActive(true);
        introText = intro.transform.GetChild(2).transform.GetComponent<TypewriterText>();
        introText.fullText = "\nDear Detective Paws,\n\nRecently, a hoard of ghosts has taken\n\nup residence in my manor. Seeing as\n\nyou are the top detective, I request\n\nyour presence immediately.\n\n\t\tBest wishes, Madame Chatte.";
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
