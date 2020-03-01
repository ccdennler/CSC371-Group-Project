using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI lives_text;
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerMovement.lives;
        lives_text.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lives = PlayerMovement.lives;
        lives_text.text = lives.ToString();
    }
}