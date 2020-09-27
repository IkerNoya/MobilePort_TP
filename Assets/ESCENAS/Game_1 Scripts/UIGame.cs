using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [SerializeField] GameManager_1 manager;
    [SerializeField] GameObject Joystick1;
    [SerializeField] GameObject Joystick2;
    public Text timerText;
    float timer;
    // Update is called once per frame
    private void Start()
    {
#if UNITY_STANDALONE
        Joystick1.SetActive(false);
        Joystick2.SetActive(false);
#elif UNITY_ANDROID
        Joystick1.SetActive(true);
        Joystick2.SetActive(true);
#endif
    }
    void Update()
    {
        timer = manager.GetTimer();
        timerText.text = timer.ToString();
    }
}
