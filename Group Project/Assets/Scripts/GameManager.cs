using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int lives;
    public TextMeshProUGUI lives_text;
    public GameObject game;
    Game games;
    // Start is called before the first frame update
    void Start()
    {
        games = game.GetComponent<Game>();
        lives_text.text = "x" + games.lives;        
    }

    // Update is called once per frame
    void Update()
    {
        lives_text.text = "x" + games.lives;
    }

    void UpdateLives()
    {

    }

    public int Lives()
    {
        return lives;
    }
}
