using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_1 : MonoBehaviour
{
    static GameManager_1 instance;
    public static GameManager_1 Instance
    {
        get { if (instance == null) instance = new GameManager_1(); return instance; }
    }
    public enum GameState
    {
        Game, 
        Unload
    }
    public GameState state;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
