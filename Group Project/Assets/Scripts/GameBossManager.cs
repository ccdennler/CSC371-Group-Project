﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameBossManager : MonoBehaviour
{
    private int piecesLeft;
    public TextMeshProUGUI piecesText;
    // Start is called before the first frame update
    void Start()
    {
        piecesLeft = BossBattle.piecesLeft;
    }

    // Update is called once per frame
    void Update()
    {
        piecesLeft = BossBattle.piecesLeft;
        piecesText.text = "Pieces Left: " + piecesLeft;
    }
}
