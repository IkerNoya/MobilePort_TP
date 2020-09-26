using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    public Text winner;
    public Text moneyP1;
    public Text moneyP2;
    DataManager data;
    string winnerA = "Player 1";
    string winnerB = "Player 2";
    void Start()
    {
        data = DataManager.Get();
        if(data.player1money > data.player2money)
            winner.text = winnerA + " wins!";
        else
            winner.text = winnerB + " wins!";
        moneyP1.text = "PLAYER1: " + data.player1money.ToString();
        moneyP2.text = "PLAYER2: " + data.player2money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
