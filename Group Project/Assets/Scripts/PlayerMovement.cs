using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    static public int lives = 9;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    public GameObject flashlight;
    bool flashlightOn = false;

    public Text characterName;
    public GameObject dialogueBackground;
    public Text dialogue;

    static public Vector3 startPos = new Vector3(-9.8f, 0, -3.2f);
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");   
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.y = 0f;
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);        
        m_Rotation = Quaternion.LookRotation (desiredForward);

        if (Input.GetMouseButtonDown(1))
        {
            if (flashlightOn)
            {
                flashlight.SetActive(false);
                flashlightOn = false;
            }
            else
            {
                flashlight.SetActive(true);
                flashlightOn = true;
            }
        }
    }

    void OnAnimatorMove ()
    {   
        m_Rigidbody.MoveRotation (m_Rotation);
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Door"))
        {
            Debug.Log("Door");
        }
    }


    //Move into dialogue script aka dialogue.text = Dialogue.GetDialogue("Punchy")
    void OnCollisionStay(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Punchy")
        {
            characterName.gameObject.SetActive(true);
            dialogueBackground.SetActive(true);
            dialogue.gameObject.SetActive(true);
            characterName.text = "Punchy";
            dialogue.text = "Just chilling in the bathroom. I wonder where Rosie is... maybe her room?";
        }
        else if (collision.gameObject.name == "Rosie")
        {
            characterName.gameObject.SetActive(true);
            dialogueBackground.SetActive(true);
            dialogue.gameObject.SetActive(true);
            characterName.text = "Punchy";
            dialogue.text = "Detective you have to get me out of here! I cannot believe I am couped up in this ratty hotel.";
        }
        else
        {
            characterName.gameObject.SetActive(false);
            dialogueBackground.SetActive(false);
            dialogue.gameObject.SetActive(false);
        }
    }

}