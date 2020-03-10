using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed = 100f;
    private float horizontalInput;
    private Vector3 offset = new Vector3(0, 3f, -1.5f);
    Movement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.isTalking)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.position = player.transform.position + offset;
            transform.RotateAround(player.transform.position, Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
            offset = transform.position - player.transform.position;
        }
       
    }
}
