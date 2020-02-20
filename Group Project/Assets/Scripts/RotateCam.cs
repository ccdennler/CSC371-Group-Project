using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;
    private bool rotateL;
    private bool rotateR;
    private float rotateSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.transform.position;
        rotateL = false;
        rotateR = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            rotateL = true;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            rotateL = false;
        }
        if (rotateL)
        {
            transform.RotateAround(playerPos, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotateR = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            rotateR = false;
        }
        if (rotateR)
        {
            transform.RotateAround(playerPos, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
    }
}
