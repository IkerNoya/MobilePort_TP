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
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
