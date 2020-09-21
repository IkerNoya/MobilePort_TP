using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public Text winner;
    DataManager data;
    string winnerA = "Player 1";
    string winnerB = "Player 2";
    void Start()
    {
        data = DataManager.Get();
        if(data.player1Score > data.player2Score)
            winner.text = winnerA + " wins!";
        else
            winner.text = winnerB + " wins!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
