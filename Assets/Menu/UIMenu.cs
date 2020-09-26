using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;


public class UIMenu : MonoBehaviour
{
    [SerializeField] Transform[] buttonsPos;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] menuAnim;
    [SerializeField] float rotatePointer = 20;
    public static event Action<UIMenu> resetPoints;
    bool selectedButton;

    private void Start()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        buttons[0].SetActive(true);
        buttons[3].SetActive(true);
    }
    void Update()
    {
        for (int i = 0; i < menuAnim.Length; i++)
        {
            if (menuAnim[i] != null)
            {
                menuAnim[i].transform.Rotate(0, rotatePointer, 0);
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    menuAnim[i].transform.position = new Vector3(menuAnim[i].transform.position.x, EventSystem.current.currentSelectedGameObject.transform.position.y, menuAnim[i].transform.position.z);
                }
            }
        }
        if (buttons[0].activeSelf && !buttons[1].activeSelf)
            selectedButton = true;
        else if (buttons[1].activeSelf && !buttons[0].activeSelf)
            selectedButton = false;
        if (EventSystem.current.currentSelectedGameObject != null)
            return;
        if(selectedButton)
            EventSystem.current.SetSelectedGameObject(buttons[0]);
        else
            EventSystem.current.SetSelectedGameObject(buttons[1]);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Loading " + sceneName);
        if (sceneName == "Game_1")
        {
            resetPoints(this);
        }
    }
    public void DeactivateButton()
    {
        buttons[0].SetActive(false);
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
