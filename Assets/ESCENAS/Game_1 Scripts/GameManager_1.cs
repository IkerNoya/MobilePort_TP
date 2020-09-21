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
	[SerializeField] GameObject player1;
	[SerializeField] GameObject player2;

    public enum GameState
    {
        Game, 
        Unload
    }
    public GameState state;
    void Start()
    {
        PlayerScript.changeCams += CameraChange;
    }

   
    void Update()
    {
        
    }
	void CambiarACarrera()
	{
		state = GameManager_1.GameState.Game;
	}
    void CameraChange()
    {
        Debug.Log("HIJO DE PUTA!");
    }
    private void OnDisable()
    {
        PlayerScript.changeCams -= CameraChange;
    }

}
