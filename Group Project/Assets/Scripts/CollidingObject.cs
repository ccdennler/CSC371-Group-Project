using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingObject : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    private void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            gameEnding.CaughtPlayer();
        }
    }

    void Update()
    {

    }
}