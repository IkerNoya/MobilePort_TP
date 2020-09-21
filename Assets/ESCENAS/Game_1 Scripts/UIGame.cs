using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] GameManager_1 manager;
    public Text timerText;
    float timer;
    // Update is called once per frame
    void Update()
    {
        timer = manager.GetTimer();
        timerText.text = timer.ToString();
    }
}
