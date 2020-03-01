using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float speed = 2f;
    public float turnSpeed = 120f;
    private float horizontalInput;
    private float verticalInput;
    public bool isTalking = false;
    private bool isNearNPC = false;
    public string talkingTo = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isTalking)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        if (isNearNPC)
        {
            if (Input.GetMouseButtonDown(0))
                isTalking = !isTalking;
            
        }
        else
            if (Input.GetMouseButtonDown(0))
            isTalking = false;
    }

    void OnTriggerStay(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "NPC")
        {
            isNearNPC = true;
            talkingTo = collision.gameObject.name;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            isNearNPC = false;
            talkingTo = "";
        }
    }
}
