using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_1 : MonoBehaviour
{
    static GameManager_1 instance;
    public static GameManager_1 Instance
    {
        get { if (instance == null) instance = new GameManager_1(); return instance; }
    }
	[SerializeField] GameObject player1;
	[SerializeField] GameObject player2;
    public float timer = 90;

    public enum GameState
    {
        Game, 
        Unload
    }
    public GameState state;
    private void OnEnable()
    {
        EndGame.ChangeScene += LoadScene;
    }
    void Start()
    {
        
    }

   public float GetTimer()
   {
       return timer;
   }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(WaitTime());
        }
    }
    void LoadScene(EndGame changescene)
    {
        StartCoroutine(WaitTime());
    }
    private void OnDisable()
    {
        EndGame.ChangeScene -= LoadScene;
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("End");
        yield return null;
    }

}
