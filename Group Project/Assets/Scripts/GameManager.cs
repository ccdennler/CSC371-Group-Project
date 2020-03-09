using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int lives;
    public TextMeshProUGUI lives_text;    
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerMovement.lives;
        lives_text.text = "x" + lives;        
    }

    // Update is called once per frame
    void Update()
    {
        lives = PlayerMovement.lives;
        lives_text.text = "x" + lives;
    }

    void UpdateLives()
    {

    }

    public int Lives()
    {
        return lives;
    }
}
