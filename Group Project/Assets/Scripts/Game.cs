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
    public GameObject dotdotdot;
    public GameObject Madame;
    public GameObject Chives;
    public GameObject Hops;
    public GameObject Snowball;
    public GameObject Professor;
    public GameObject Scratch;
    public GameObject Claw;
    public GameObject NiceGhost;
    public float fadeDuration = 1000f;
    public float displayImageDuration = 1000f;
    float m_Timer;
    GameObject dialogue;
    Text characterName;
    TypewriterText typewriter;
    Movement playerMovement;
    TypewriterText introText;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<Movement>();
        Madame.transform.position = new Vector3(0, 2, -5.5f);
        Madame.transform.rotation = Quaternion.Euler(0, 180, 0);
        Chives.transform.position = new Vector3(32, 2, 10);
        Chives.transform.rotation = Quaternion.Euler(0, 180, 0);
        Claw.transform.position = new Vector3(0.27f, 2, 15);
        Claw.transform.rotation = Quaternion.Euler(0, 180, 0);
        Scratch.transform.position = new Vector3(-1.05f, 2, 15);
        Scratch.transform.rotation = Quaternion.Euler(0, 180, 0);
        Professor.transform.position = new Vector3(50, 2, 10);
        Professor.transform.rotation = Quaternion.Euler(0, 45, 0);
        Hops.transform.position = new Vector3(0, 1, 37);
        Hops.transform.rotation = Quaternion.Euler(0, 90, 0);
        Snowball.transform.position = new Vector3(-35, 2, 10);
        Snowball.transform.rotation = Quaternion.Euler(0, 180, 0);
        NiceGhost.transform.position = new Vector3(-3, 1, 37);
        NiceGhost.transform.rotation = Quaternion.Euler(0, 90, 0);
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
        introText.fullText = "\nDear Detective Paws,\n\nRecently, a horde of ghosts has taken\n\nup residence in my manor. Seeing as\n\nyou are the top detective, I request\n\nyour presence immediately.\n\n\t\tBest wishes, Madame Chatte.";
        if (Input.GetMouseButtonDown(0))
        {
            stage = 0;
            intro.SetActive(false);
        }
    }

    private void CheckDialogue()
    {
        if (playerMovement.isNearNPC)
        {
            dotdotdot.transform.position = new Vector3(playerMovement.posNPC.x, dotdotdot.transform.position.y, playerMovement.posNPC.z);
            dotdotdot.SetActive(true);
        }
        else
        {
            dotdotdot.SetActive(false);
        }
        if (playerMovement.isTalking)
        {
            dotdotdot.SetActive(false);
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
        if (DialogueSystem.stage0 && !playerMovement.isTalking)
        {
            stage = 1;
            Madame.transform.position = new Vector3(0, 2, -5.5f);
            Madame.transform.rotation = Quaternion.Euler(0, 180, 0);
            Chives.transform.position = new Vector3(32, 2, 10);
            Chives.transform.rotation = Quaternion.Euler(0, 180, 0);
            Claw.transform.position = new Vector3(0.27f, 2, 15);
            Claw.transform.rotation = Quaternion.Euler(0, 180, 0);
            Scratch.transform.position = new Vector3(-1.05f, 2, 15);
            Scratch.transform.rotation = Quaternion.Euler(0, 180, 0);
            Professor.transform.position = new Vector3(-36, 7.2f, 9);
            Professor.transform.rotation = Quaternion.Euler(0, 90, 0);
            Hops.transform.position = new Vector3(-7.5f, 1, 40);
            Hops.transform.rotation = Quaternion.Euler(0, 0, 0);
            Snowball.transform.position = new Vector3(-52, 2, 12);
            Snowball.transform.rotation = Quaternion.Euler(0, 180, 0);
            NiceGhost.transform.position = new Vector3(48, 7f,-2);
            NiceGhost.transform.rotation = Quaternion.Euler(0, 0, 0);
            DialogueSystem.ResetTalk();
        }
        if (DialogueSystem.stage1 && !playerMovement.isTalking)
        {
            stage = 2;
            Madame.transform.position = new Vector3(0, 2, -5.5f);
            Madame.transform.rotation = Quaternion.Euler(0, 180, 0);
            Chives.transform.position = new Vector3(32, 2, 10);
            Chives.transform.rotation = Quaternion.Euler(0, 180, 0);
            Claw.transform.position = new Vector3(58, 2, -4);
            Claw.transform.rotation = Quaternion.Euler(0, 180, 0);
            Scratch.transform.position = new Vector3(52, 2, -4);
            Scratch.transform.rotation = Quaternion.Euler(0, 180, 0);
            Professor.transform.position = new Vector3(-36, 7.2f, 9);
            Professor.transform.rotation = Quaternion.Euler(0, 90, 0);
            Hops.transform.position = new Vector3(-7.5f, 1, 40);
            Hops.transform.rotation = Quaternion.Euler(0, 0, 0);
            Snowball.transform.position = new Vector3(-4.6f, 2, 1);
            Snowball.transform.rotation = Quaternion.Euler(0, 180, 0);
            NiceGhost.transform.position = new Vector3(-21.4f, 7.5f, 8.5f);
            NiceGhost.transform.rotation = Quaternion.Euler(0, 0, 0);
            DialogueSystem.ResetTalk();
        }
        if (DialogueSystem.stage2 && !playerMovement.isTalking)
        {
            stage = 3;
            Madame.transform.position = new Vector3(0, 2, -5.5f);
            Madame.transform.rotation = Quaternion.Euler(0, 180, 0);
            Chives.transform.position = new Vector3(32, 2, 10);
            Chives.transform.rotation = Quaternion.Euler(0, 180, 0);
            Claw.transform.position = new Vector3(-42.4f, 2, 1.2f);
            Claw.transform.rotation = Quaternion.Euler(0, 180, 0);
            Scratch.transform.position = new Vector3(-41f, 2, 1.3f);
            Scratch.transform.rotation = Quaternion.Euler(0, 180, 0);
            Professor.transform.position = new Vector3(-36, 7.2f, 9);
            Professor.transform.rotation = Quaternion.Euler(0, 90, 0);
            Hops.transform.position = new Vector3(-7.5f, 1, 40);
            Hops.transform.rotation = Quaternion.Euler(0, 0, 0);
            Snowball.transform.position = new Vector3(-52, 2, 12);
            Snowball.transform.rotation = Quaternion.Euler(0, 180, 0);
            NiceGhost.transform.position = new Vector3(-21.4f, 7.5f, 8.5f);
            NiceGhost.transform.rotation = Quaternion.Euler(0, 0, 0);
            DialogueSystem.ResetTalk();
        }
    }

}
