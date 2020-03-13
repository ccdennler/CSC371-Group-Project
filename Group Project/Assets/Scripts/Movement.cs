﻿using System.Collections;
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
    public bool isNearNPC = false;
    public string talkingTo = "";
    private bool isNearItem = false;
    public string itemTo = "";
    public Vector3 posNPC;
    public float overheatLevel;
    public bool overheated;
    public GameObject flashlight;
    bool flashlightOn = false;
    public static int lives = 9;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        overheatLevel = 0;
        overheated = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0f);
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0f);
        bool isWalking = hasVerticalInput;
        //animator.SetBool("IsWalking", isWalking);
        if (!isTalking)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        if (isNearNPC || isNearItem)
        {
            if (Input.GetMouseButtonDown(0))
                isTalking = !isTalking;
            
        }
        else if (Input.GetMouseButtonDown(0))
            isTalking = false;
        if (flashlightOn)
        {
            if (!isTalking)
                overheatLevel++;
            if (Input.GetMouseButtonDown(1))
            {
                flashlight.SetActive(false);
                flashlightOn = false;
            }
            if (overheatLevel > 150)
            {
                overheated = true;
                flashlight.SetActive(false);
                flashlightOn = false;
            }
        }
        else
        {
            if (overheatLevel > 0)
                overheatLevel = overheatLevel - 2;
            else
                overheated = false;
            if (Input.GetMouseButtonDown(1) && !overheated)
            {
                flashlight.SetActive(true);
                flashlightOn = true;
            }
        }
    }

    void OnTriggerStay(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "NPC" || collision.gameObject.tag == "Dialogue Item")
        {
            isNearNPC = true;
            talkingTo = collision.gameObject.name;
            posNPC = collision.gameObject.transform.position;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "NPC" || collision.gameObject.tag == "Dialogue Item")
        {
            isNearNPC = false;
            talkingTo = "";
        }
    }
    

}
