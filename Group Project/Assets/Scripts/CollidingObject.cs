using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollidingObject : MonoBehaviour
{
    public Transform player;
    public GameObject parent;
    public Transform flashlight;
    public GameEnding gameEnding;
    public NavMeshAgent navMesh;
    public AudioSource ghostNoise;
    public GameObject ghostDeath;

    public float health = 100.0f;

    private float savespeed;
    private Quaternion saverot;

    private void Start()
    {
        navMesh = parent.GetComponent<NavMeshAgent>();
        ghostNoise = parent.GetComponent<AudioSource>();
        savespeed = navMesh.speed;
        saverot = parent.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            gameEnding.CaughtPlayer();
        }
        if (other.transform == flashlight)
        {
            navMesh.speed = 0;
            saverot = parent.transform.rotation;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.transform == flashlight)
        {
            parent.transform.Rotate(Vector3.up, 8);
            

            health -= 1;
            if (health % 10 == 0)
            {
                ghostNoise.volume += 0.04f;
                ghostNoise.pitch += 0.04f;
            }
            if (health == 0)
            {
                Vector3 offset = new Vector3(0, 0.5f, 0);
                Instantiate(ghostDeath, parent.transform.position + offset, Quaternion.Euler(-90, 0, 0));
                Destroy(parent);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == flashlight)
        {
            navMesh.speed = savespeed + 0.1f;
            savespeed = navMesh.speed;
            parent.transform.rotation = saverot;
        }
    }

    void Update()
    {

    }
}