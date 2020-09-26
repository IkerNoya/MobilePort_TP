using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public float player1money;
    public float player2money;
    int moneyGain = 250000;
    public static DataManager Get()
    {
        return instance;
    }
    void OnEnable()
    {
        UIMenu.resetPoints += ResetScore;
        PlayerScript.AddMoney1 += AddScore1;
        PlayerScript.AddMoney2 += AddScore2;
    }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
    void AddScore1(PlayerScript addmoney)
    {
        player1money += moneyGain;
    }
    void AddScore2(PlayerScript addmoney)
    {
        player1money += moneyGain;
    }

    void ResetScore(UIMenu reset)
    {
        player1money = 0;
        player2money = 0;
    }
    void OnDisable()
    {
        UIMenu.resetPoints -= ResetScore;
        PlayerScript.AddMoney1 -= AddScore1;
        PlayerScript.AddMoney2 -= AddScore2;
    }
}
