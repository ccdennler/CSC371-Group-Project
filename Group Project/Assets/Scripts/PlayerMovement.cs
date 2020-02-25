using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public float turnSpeed = 20f;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    private const float walk = 1.0f;
    private const float run = 2.0f;
    private float move_speed;
    private Vector3 cam_offset = new Vector3(0, 16f, -10f);
    private string cam_dir;

    public Text characterName;
    public GameObject dialogueBackground;
    public Text dialogue;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
        move_speed = walk;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");   
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement = Camera.main.transform.rotation * m_Movement;
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
        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            move_speed = run;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            move_speed = walk;
        }
        cam.transform.position = cam_offset + m_Rigidbody.transform.position;
    }

    void OnAnimatorMove ()
    {   
        m_Rigidbody.MoveRotation (m_Rotation);
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude * move_speed);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Door"))
        {
            Vector3 rel_pos = transform.position - other.gameObject.transform.position;
            Vector3 rel_dir = new Vector3(rel_pos.x, 0, rel_pos.z).normalized;
            rel_dir = cam.transform.InverseTransformDirection(rel_dir);
            if (rel_dir.x < 0 && cam_dir != "left")
            {
                Vector3 camRot = cam.transform.eulerAngles;
                camRot.y += 90.0f;
                cam.transform.eulerAngles = camRot;

                cam_offset.x = -10f;
                cam_offset.z = 0;

                cam.transform.position = transform.position + cam_offset;                
                
                cam_dir = "left";
            }
            else if (rel_dir.x > 0 && cam_dir != "right")
            {
                Vector3 camRot = cam.transform.eulerAngles;
                camRot.y += -90.0f;
                cam.transform.eulerAngles = camRot;

                cam_offset.x = 10f;
                cam_offset.z = 0;

                cam.transform.position = transform.position + cam_offset;
                

                cam_dir = "right";
            }
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