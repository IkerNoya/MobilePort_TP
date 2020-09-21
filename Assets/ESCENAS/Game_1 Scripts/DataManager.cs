using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public float player1Score;
    public float player2Score;
    public static DataManager Get()
    {
        return instance;
    }
    void OnEnable()
    {
        UIMenu.resetPoints += ResetScore;
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
    void addScore1(EndGame addscore1)
    {
        player1Score++;
    }
    void addScore2(EndGame addscore2)
    {
        player2Score++;
    }
    void ResetScore(UIMenu reset)
    {
        player1Score = 0;
        player2Score = 0;
    }
    void OnDisable()
    {
        UIMenu.resetPoints -= ResetScore;
    }
}
